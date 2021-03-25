using Farm.Api.Interfaces;
using Farm.DAL.Interfaces;
using Farm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Farm.Api.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IFarmDbContext DbContext;

        private readonly DbSet<T> DbSet;

        public BaseService(IFarmDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<T>();
        }

        public EntityState Create(T entity)
        {
            return DbSet.Add(entity).State;
        }

        public async Task<EntityState> CreateAsync(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            return result.State;
        }

        public EntityState Delete(T entity)
        {
            var state = DbSet.Remove(entity).State;

            return state;
        }

        public IQueryable<T> GetAll() => DbSet;

        public T GetById(Guid id) => DbSet.Find(id);

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => DbSet.Where(predicate);

        public async Task<T> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);

        public EntityState Update(Guid id, T entity)
        {
            var oldEntity = GetById(id);

            if (oldEntity != null)
            {
                var state = DbSet.Update(oldEntity).State;

                SaveChanges();

                return state;
            }

            return EntityState.Unchanged;
        }

        public void SaveChanges() => DbContext.SaveChanges();
    }
}
