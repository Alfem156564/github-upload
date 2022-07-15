namespace Data.Providers.Database
{
    using Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PasatiempoDatabaseContext : DbContext
    {
        public DbSet<AnimeEntity> Anime { get; set; }

        public PasatiempoDatabaseContext()
        {
        }

        public PasatiempoDatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESARROLLO-ALAN\\DESARROLLOSITHEC;Database=test-db;User Id=sa;Password=black;", 
                        x => x.MigrationsHistoryTable("_PasatiempoMigrationsHistory", "Pasatiempo"));
            }
            else
            {
                optionsBuilder
                        .UseSqlServer(x => x.MigrationsHistoryTable("_PasatiempoMigrationsHistory", "Pasatiempo"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeEntity>()
            .Property(e => e.Personajes)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
