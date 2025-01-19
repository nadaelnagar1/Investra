namespace Investra_BAL.Domains.Stocks.Validators
{
    public class StockForUpdateDtoValidator : AbstractValidator<StockForUpdateDto>
    {
        public StockForUpdateDtoValidator()
        {
            RuleFor(x => x.Symbol).NotEmpty().MaximumLength(10);
            RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Purchase).NotEmpty().GreaterThan(0);
            RuleFor(x => x.LastDiv).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Industry).NotEmpty().MaximumLength(50);
            RuleFor(x => x.MarketCap).NotEmpty().GreaterThan(0);
        }
    }
}
