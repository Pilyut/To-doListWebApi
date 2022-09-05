using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Security.Claims;
using BusinessLogicLayer.DTO;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }
        
        [HttpPost("~/Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            UserDTO userDTO = new() { Login = model.Email, Password = model.Password, UserName = model.UserName };
            if (await _service.HasUser(userDTO) == false)
            {
                if (await _service.IsUserNameTaken(model.UserName) == false)
                {
                    await _service.AddUser(userDTO);
                    await Authenticate(model.Email);
                }
                else
                    ModelState.AddModelError("", "Username name is taken");
            }
            else
                ModelState.AddModelError("", "The user with this login is busy");
            return Ok("User created");
        }
        
        [HttpPost("~/Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            UserDTO userDTO = new() { Login = model.Email, Password = model.Password };
            if (await _service.HasUser(userDTO))
            {
                await Authenticate(model.Email);
            }
            else
                ModelState.AddModelError("", "Incorrect login and/or password");
            return Ok();
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet("~/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
