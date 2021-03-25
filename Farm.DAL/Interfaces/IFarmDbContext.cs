using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Farm.DAL.Interfaces
{
    public interface IFarmDbContext
    {
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool accecptAllChangeOnSuccess, CancellationToken cancellationToken);
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>([System.Diagnostics.CodeAnalysis.NotNull] TEntity entity) where TEntity : class;
    }
}
