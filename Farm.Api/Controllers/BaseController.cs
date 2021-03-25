using Farm.Api.Interfaces;
using Farm.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farm.Api.Controllers
{
    // TO-DO: Add odata for better performance on filter, selection etc...
    // TO-DO: Inject a General Exception handler on the middlware.
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T, S> : Controller where S : IService<T> where T : BaseEntity
    {
        protected readonly IService<T> _entityService;

        public BaseController(S serivce) => _entityService = serivce;

        // GET: api/Controller
        [HttpGet]
        public virtual ActionResult<IQueryable<T>> Get() => new ObjectResult(_entityService.GetAll());

        // PUT: api/Controller/Entities/{id}
        [HttpPut]
        public IActionResult Put(Guid id, T entity)
        {
            _entityService.Update(id, entity);

            return new OkResult();
        }

        // POST: api/Controller/Entities
        [HttpPost]
        public async Task<ActionResult<T>> Post(T entity)
        {
            await _entityService.CreateAsync(entity);

            return new OkResult();
        }

        // DELETE: api/Controller/Entities/{id}
        [HttpDelete]
        public async Task<ActionResult<T>> Delete(Guid id)
        {
            var entity = await _entityService.GetByIdAsync(id);

            if (entity != null)
            {
                _entityService.Delete(entity);
            }

            return new OkResult();
        }
    }
}
