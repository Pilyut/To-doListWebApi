using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return await _service.GetUsersList();
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO userDTO)
        {
            await _service.AddUser(userDTO);
            return Ok($"User Added (UserName : {userDTO.UserName})");
        }
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Put(int id, string newUserName)
        {
            await _service.UpdateUserName(id, newUserName);
            return Ok($"UserName changed to {newUserName}");
        }
        [HttpDelete]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            await _service.DeleteUser(id);
            return Ok($"User deleted");
        }
    }
}
