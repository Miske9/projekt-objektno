using Microsoft.EntityFrameworkCore;
namespace tutorial_wpf
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
              .HasMany(p => p.TransferHistory)
              .WithOne()
              .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=../../../football.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}