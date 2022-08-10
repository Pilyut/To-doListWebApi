using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTO;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> Get(int id)
        {
            return await _service.GetAllAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoDTO>> Post(ToDoDTO toDoDTO, int userId)
        {
            await _service.Add(toDoDTO, userId);
            return Ok(toDoDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ToDoDTO>> Put(ToDoDTO toDoDTO, int userId)
        {
            await _service.Update(toDoDTO, userId);
            return Ok();
        }

        [Route("mark")]
        [HttpPut]
        public async Task<ActionResult<ToDoDTO>> Put(int userId)
        {
            await _service.MarkComplete(userId);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<ToDoDTO>> Delete(int todoId)
        {
            await _service.Delete(todoId);
            return Ok();
        }
    }
}
