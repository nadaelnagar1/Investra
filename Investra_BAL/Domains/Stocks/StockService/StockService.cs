namespace Investra_BAL.Domains.Stocks.StockService
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IGenericService _genericService;
        private readonly ApplicationDbContext _context;
        private readonly StockForCreateDtoValidator _stockForCreateDtoValidator;
        private readonly StockForUpdateDtoValidator _stockForUpdateDtoValidator;
        public StockService(IStockRepository stockRepository, IGenericService genericService, ApplicationDbContext context, StockForCreateDtoValidator stockForCreateDtoValidator, StockForUpdateDtoValidator stockForUpdateDtoValidator)
        {
            _context = context;
            _stockRepository = stockRepository;
            _genericService = genericService;
            _stockForCreateDtoValidator = stockForCreateDtoValidator;
            _stockForUpdateDtoValidator = stockForUpdateDtoValidator;
          
        }

        public Task<OneOf<StockForReadDto, Response>> AddStock(StockForCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<StockForReadDto, Response>> DeleteStock(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StockForReadDto>> GetAllStocks()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<StockForReadDto, Response>> GetStockById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<StockForReadDto, Response>> UpdateStock(Guid id, StockForUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
