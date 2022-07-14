﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.ToDo;
using Services;

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

        [Route("mark")]
        [HttpPut]
        public async Task<ActionResult<ToDoClass>> Put(int id)
        {
            await _service.MarkComplete(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<ToDoClass>> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
