namespace Investra_DAL.Database.ApplicationDbContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public virtual DbSet<Stock> Stocks { get; set; }

    }
}
