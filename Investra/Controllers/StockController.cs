namespace Investra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpGet("GetAllStocks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStocks()
        {
            var result = await _stockService.GetAllStocks();
            if (result != null)
                return Ok(result);
            return Ok();
        }


        [HttpGet("GetStockById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStockById(Guid id)
        {
            var result = await _stockService.GetStockById(id);
            return result.IsT0 ? Ok(result.AsT0) : NotFound(result.AsT1);
        }

        [HttpPost("AddStock")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStock(StockForCreateDto dto)
        {
            var result = await _stockService.AddStock(dto);
            return result.IsT0 ? Ok(result.AsT0) : BadRequest(result.AsT1);
        }

        [HttpPut("UpdateStock/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStock(Guid id, StockForUpdateDto dto)
        {
            var result = await _stockService.UpdateStock(id, dto);
            return result.IsT0 ? Ok(result.AsT0) : BadRequest(result.AsT1);
        }

        [HttpDelete("DeleteStock/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            var result = await _stockService.DeleteStock(id);
            return result.IsT0 ? Ok(result.AsT0) : NotFound(result.AsT1);
        }
    }
}
