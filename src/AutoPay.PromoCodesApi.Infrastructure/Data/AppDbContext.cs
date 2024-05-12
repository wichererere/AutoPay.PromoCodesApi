namespace AutoPay.PromoCodesApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
    : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
  public DbSet<PromoCode> PromoCodes => Set<PromoCode>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    OnBeforeSaveChanges();
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
      .Select(e => e.Entity)
      .Where(e => e.DomainEvents.Any())
      .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
    SaveChangesAsync().GetAwaiter().GetResult();

  private void OnBeforeSaveChanges()
  {
    ChangeTracker.DetectChanges();
    
    foreach (var entry in ChangeTracker.Entries().ToList())
    {
      if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
        continue;

      Dictionary<string, object> primaryKeys = [];
      Dictionary<string, object> oldValues  = [];
      Dictionary<string, object> newValues  = [];
      List<string> affectedColumns  = [];
        
      foreach (var property in entry.Properties)
      {
        string propertyName = property.Metadata.Name;
        if (property.Metadata.IsPrimaryKey())
        {
          primaryKeys[propertyName] = property.CurrentValue!;
          continue;
        }

        switch (entry.State)
        {
          case EntityState.Added:
            if (property.CurrentValue != null)
            {
              newValues[propertyName] = property.CurrentValue;
            }

            break;
          case EntityState.Deleted:
            if (property.OriginalValue != null)
            {
              oldValues[propertyName] = property.OriginalValue;
            }

            break;
          case EntityState.Modified:
          {
            if (property.IsModified)
            {
              affectedColumns.Add(propertyName);
              
              if (property.OriginalValue != null)
              {
                oldValues[propertyName] = property.OriginalValue;
              }

              if (property.CurrentValue != null)
              {
                newValues[propertyName] = property.CurrentValue;
              }
            }

            break;
          }
        }
      }

      AuditLogs.Add(new AuditLog(entry.Entity.GetType().Name, entry.State.ToString(),
        JsonSerializer.Serialize(oldValues),
        JsonSerializer.Serialize(newValues),
        JsonSerializer.Serialize(affectedColumns),
        JsonSerializer.Serialize(primaryKeys)));
    }
  }
}
