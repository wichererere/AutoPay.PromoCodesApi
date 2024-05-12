namespace AutoPay.PromoCodesApi.Infrastructure.Data;

public static class SeedData
{
    public static readonly PromoCode PromoCode1 = new("Code number 1", "Code1", 10);
    public static readonly PromoCode PromoCode2 = new("Code number 2", "Code2", 5);

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
        {
            if (dbContext.PromoCodes.Any()) return; // DB has been seeded

            PopulateTestData(dbContext);
        }
    }

    public static void PopulateTestData(AppDbContext dbContext)
    {
        foreach (var promoCode in dbContext.PromoCodes)
        {
            dbContext.Remove(promoCode);
        }

        dbContext.SaveChanges();

        dbContext.PromoCodes.Add(PromoCode1);
        dbContext.PromoCodes.Add(PromoCode2);

        dbContext.SaveChanges();
    }
}
