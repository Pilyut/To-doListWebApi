using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using System.Security.Claims;
using System.Collections.Generic;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService accountService)
        {
            _service = accountService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _service.Register(model);
            return Ok("Registration successful");
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            await _service.Login(model);
            
            return Ok();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction();
        }
    }
}
