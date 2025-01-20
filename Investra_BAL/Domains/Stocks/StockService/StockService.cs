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

        public async Task<OneOf<StockForReadDto, Response>> AddStock(StockForCreateDto dto)
        {
            var validationResult = _stockForCreateDtoValidator.Validate(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                string concatenatedErrors = string.Join("; ", errors);
                return await _genericService.CreateResponse(ResponseMessages.ValidationError, concatenatedErrors);
            }

            var adaptedStock = dto.Adapt<Stock>();
            var createdStock = await _stockRepository.AddAsync(adaptedStock);
            if (createdStock == null)
            {
                return await _genericService.CreateResponse(ResponseMessages.Error, ResponseMessages.StockCreationFailed);
            }
            return createdStock.Adapt<StockForReadDto>();
        }

        public async Task<OneOf<StockForReadDto, Response>> DeleteStock(Guid id)
        {
            var deletedStock = await _stockRepository.Delete(id);
            if (deletedStock != null)
            {
                return deletedStock.Adapt<StockForReadDto>();
            }
            return await _genericService.CreateResponse(ResponseMessages.Error, ResponseMessages.Deleted(ResponseMessages.Stock));
        }

        public async Task<List<StockForReadDto>> GetAllStocks()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return stocks.Adapt<List<StockForReadDto>>();
        }

        public async Task<OneOf<StockForReadDto, Response>> GetStockById(Guid id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock != null)
            {
                return stock.Adapt<StockForReadDto>();
            }
            return await _genericService.CreateResponse(ResponseMessages.Error, ResponseMessages.NotFound(ResponseMessages.Stock));
        }
    

        public async Task<OneOf<StockForReadDto, Response>> UpdateStock(Guid id, StockForUpdateDto dto)
        {
            var validationResult = _stockForUpdateDtoValidator.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                string concatenatedErrors = string.Join("; ", errors);
                return await _genericService.CreateResponse(ResponseMessages.ValidationError, concatenatedErrors);
            }

            var existingStock = await _stockRepository.GetByIdAsync(id);
            if (existingStock == null)
            {
                return await _genericService.CreateResponse(ResponseMessages.Error, ResponseMessages.NotFound(ResponseMessages.Stock));
            }

            dto.Adapt(existingStock);

            var updatedStock = await _stockRepository.Update(existingStock);
            if (updatedStock == null)
            {
                return await _genericService.CreateResponse(ResponseMessages.Error, ResponseMessages.UpdateFailed(ResponseMessages.Stock));
            }

            return updatedStock.Adapt<StockForReadDto>();
        }
    }
}
