namespace Data.Contracts
{
    using Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IDatabaseContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        public DbSet<UserTypeEntity> UserTypes { get; set; }
    }
}
