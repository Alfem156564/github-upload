namespace Data.Providers.Database
{
    using Data.Contracts;
    using Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<UserTypeEntity> UserTypes { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESARROLLO-ALAN\\DESARROLLOSITHEC;Database=test-db;User Id=sa;Password=black;");
            }
        }
    }
}
