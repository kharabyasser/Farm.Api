using Farm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Farm.Api.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        EntityState Create(T entity);
        Task<EntityState> CreateAsync(T entity);
        EntityState Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Guid id);
        EntityState Update(Guid id, T entity);
        void SaveChanges();
    }
}
