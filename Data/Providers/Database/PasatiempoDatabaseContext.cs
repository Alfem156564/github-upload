namespace Data.Providers.Database
{
    using Data.Models;
    using Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PasatiempoDatabaseContext : DbContext
    {
        public DbSet<AnimeEntity> Anime { get; set; }

        public DbSet<CatalogoDestinoEntity> Catalogos { get; set; }

        public virtual DbSet<GenericResult> SP_TESMantenimientoCatalogoDestino { get; set; }

        public PasatiempoDatabaseContext()
        {
        }

        public PasatiempoDatabaseContext(DbContextOptions<PasatiempoDatabaseContext> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=SITEC30008\\DESARROLLOSITHEC;Database=test-db;User Id=sa;Password=black;", 
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
            modelBuilder.Entity<GenericResult>().HasNoKey().ToView("TES.prTESMantenimientoCatalogoDestino");

            modelBuilder.Entity<AnimeEntity>()
            .Property(e => e.Personajes)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
