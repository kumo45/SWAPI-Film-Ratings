using Microsoft.EntityFrameworkCore;

namespace SWAPIFilmRatingsBLL.DLL
{
    public class SWAPIFilmRatingsDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public SWAPIFilmRatingsDbContext() : base()
        {
        }

        public SWAPIFilmRatingsDbContext(DbContextOptions<SWAPIFilmRatingsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(e => e.HasKey("Id"));
        }
    }
}