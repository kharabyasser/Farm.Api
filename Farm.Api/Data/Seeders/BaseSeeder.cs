using Farm.Api.Services;
using Farm.DAL.Interfaces;
using Farm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm.Api.Data.Seeders
{
    public class BaseSeeder<T> : BaseService<T> where T : BaseEntity
    {
        protected Lazy<IEnumerable<T>> Entities { get; set; }

        public BaseSeeder(IFarmDbContext context) : base(context) { }

        public async Task Seed()
        {
            var values = GetAll();

            if (!values.Any())
            {
                foreach (var entity in Entities.Value)
                {
                    await CreateAsync(entity);
                }

                SaveChanges();
            }
        }

    }
}
