using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using System.Text.Json;

namespace Base.Controllers
{
    [ApiController]
    public class BaseController<T> : MainController where T : Entity
    {
        private readonly IRepository<T> _db;
        public BaseController(IRepository<T> db)
        {
            _db = db;
        }

        [HttpGet]
        public virtual async Task<ActionResult> Index()
        {
            var result = await _db.Get(false);
            return CustomResponse(result);
        }

        [Route("details/{id}")]
        [HttpGet]
        public virtual async Task<ActionResult> Details(Guid id)
        {
            var result = await _db.GetById(id);
            return CustomResponse(result);
        }


        [Route("create")]
        [HttpPost]
        public virtual async Task<ActionResult> Create(T objeto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            objeto.SerializedObject = JsonSerializer.Serialize(objeto);

            var result = await _db.Create(objeto);

            return CustomResponse(result);
        }

        [Route("update")]
        [HttpPut]
        public virtual async Task<ActionResult> Update(T objeto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            objeto.SerializedObject = JsonSerializer.Serialize(objeto);

            var result = await _db.Update(objeto);

            return CustomResponse(result);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            var objeto = await _db.GetById(id);
            objeto.IsDeleted = true;

            objeto.SerializedObject = JsonSerializer.Serialize(objeto);

            var result = await _db.Delete(objeto);

            return CustomResponse(result);
        }
    }
}
