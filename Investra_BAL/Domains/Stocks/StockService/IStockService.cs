namespace Investra_BAL.Domains.Stocks.StockService
{
    public interface IStockService
    {
        Task<OneOf<StockForReadDto, Response>> GetStockById(Guid id);
        Task<List<StockForReadDto>> GetAllStocks();
        Task<OneOf<StockForReadDto, Response>> AddStock(StockForCreateDto dto);
        Task<OneOf<StockForReadDto, Response>> UpdateStock(Guid id, StockForUpdateDto dto);
        Task<OneOf<StockForReadDto, Response>> DeleteStock(Guid id);
    }
}
