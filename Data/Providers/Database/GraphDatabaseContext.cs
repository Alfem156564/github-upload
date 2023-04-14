namespace Data.Providers.Database
{
    using Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class GraphDatabaseContext : DbContext
    {
        private const string SchemaName = "Graph";

        private const string MigrationTableName = "_GraphMigrationsHistory";

        public DbSet<CertificatesOfferEntity> CertificatesOffers { get; set; }

        public DbSet<CertificatesCounterOfferEntity> CertificatesCounterOffers { get; set; }

        public DbSet<EnergyOfferEntity> EnergyOffers { get; set; }

        public GraphDatabaseContext()
        {
        }

        public GraphDatabaseContext(DbContextOptions<GraphDatabaseContext> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=SITEC30008\\DESARROLLOSITHEC;Database=test-db;User Id=sa;Password=black;", 
                        x => x.MigrationsHistoryTable(MigrationTableName, SchemaName));
            }
            else
            {
                optionsBuilder
                        .UseSqlServer(x => x.MigrationsHistoryTable(MigrationTableName, SchemaName));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);
        }
    }
}
