using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessLogicLayer.DTO;
using AutoMapper;
using DataAccessLayer.Entities;

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
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> Get()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoDTO>> Post(ToDoDTO toDoDTO)
        {
            await _service.Add(toDoDTO);
            return Ok(toDoDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ToDoDTO>> Put(int id, ToDoDTO toDo)
        {
            await _service.Update(id, toDo.Task);
            return Ok(toDo);
        }

        [Route("mark")]
        [HttpPut]
        public async Task<ActionResult<ToDoDTO>> Put(int id)
        {
            await _service.MarkComplete(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<ToDoDTO>> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
