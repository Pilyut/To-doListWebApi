using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoWebApi.Services;
using ToDoWebApi.DataBase;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoService _service;
        public ToDoController(ToDoService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoClass>>> Get()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoClass>> Post(ToDoClass toDo)
        {
            await _service.Add(toDo);
            return Ok(toDo);
        }

        [HttpPut]
        public async Task<ActionResult<ToDoClass>> Put(int id, ToDoClass toDo)
        {
            await _service.Update(id, toDo.Task);
            return Ok(toDo);
        }

        [HttpDelete]
        public async Task<ActionResult<ToDoClass>> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
