namespace Investra_BAL.Domains.Stocks.Validators
{
    public class StockForCreateDtoValidator : AbstractValidator<StockForCreateDto>
    {
        public StockForCreateDtoValidator()
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
