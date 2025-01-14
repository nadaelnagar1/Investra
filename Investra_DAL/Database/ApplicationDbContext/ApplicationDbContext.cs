namespace Investra_DAL.Database.ApplicationDbContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Stock)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.StockId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

    }
}
