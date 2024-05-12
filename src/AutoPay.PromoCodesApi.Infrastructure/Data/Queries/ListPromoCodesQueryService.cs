namespace AutoPay.PromoCodesApi.Infrastructure.Data.Queries;

public class ListPromoCodesQueryService(AppDbContext _db) : IListPromoCodesQueryService
{
    public async Task<IEnumerable<PromoCodeDTO>> ListAsync()
    {
        var result = await _db.Database.SqlQuery<PromoCodeDTO>(
                $"SELECT Id, Name, Code, MaxPossibleDownloads, IsActive FROM PromoCodes")
            .ToListAsync();

        return result;
    }
}
