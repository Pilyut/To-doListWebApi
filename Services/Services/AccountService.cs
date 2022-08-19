using BusinessLogicLayer.Interfaces;
using DataAccessLayer.EF;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly ToDoContext _database;
        private readonly IUserService _userService;
        public AccountService(ToDoContext database, IUserService userService)
        {
            _database = database;
            _userService = userService;
        }
        public async Task Register(RegisterModel model)
        {
            User user = await _database.Users.FirstOrDefaultAsync(u => u.Login == model.Email);
            if (user == null)
            {
                UserDTO userDTO = new UserDTO { Login = $"{model.Email}", Password = $"{model.Password}"};
                await _userService.AddUser(userDTO);
            }
            else
            {
                
            }
        }
        public async Task Login(LoginModel model)
        {
            User user = await _database.Users.FirstOrDefaultAsync(u => u.Login == model.Email);
            if (user != null)
            {
                Authenticate(model.Email);
            }
        }
        private ClaimsIdentity Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
           // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}
