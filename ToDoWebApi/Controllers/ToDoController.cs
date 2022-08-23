using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ToDoWebApi.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> Get(int userId)
        {
            return await _service.GetAllAsync(userId);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoDTO>> Post(ToDoDTO toDoDTO, int userId)
        {
            await _service.Add(toDoDTO, userId);
            return Ok(toDoDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ToDoDTO>> Put(ToDoDTO toDoDTO, int todoId)
        {
            await _service.Update(toDoDTO, todoId);
            return Ok();
        }

        [Route("mark")]
        [HttpPut]
        public async Task<ActionResult<ToDoDTO>> Put(int todoId)
        {
            await _service.MarkComplete(todoId);
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
