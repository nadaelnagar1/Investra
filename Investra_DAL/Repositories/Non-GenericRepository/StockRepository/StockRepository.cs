namespace Investra_DAL.Repositories.Non_GenericRepository.StockRepository
{
    public class StockRepository : BaseRepository<Stock> , IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
