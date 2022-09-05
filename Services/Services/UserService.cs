using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.EF;
using AutoMapper;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ToDoContext _database;
        private readonly IMapper _mapper;

        public UserService(ToDoContext database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUserList()
        {
            List<UserDTO> listDTO = new();
            var list = await _database.Users.ToListAsync();
            foreach (var user in list)
            {
                var todo = _mapper.Map<UserDTO>(user);
                listDTO.Add(todo);
            }
            return listDTO;
        }

        public async Task AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
        }

        public async Task UpdateUserName(int id, string newUserName)
        {
            var user = await _database.Users.FirstOrDefaultAsync(x => x.Id == id);
            user.UserName = newUserName;
            _database.Users.Update(user);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _database.Users.FirstOrDefaultAsync(x => x.Id == id);
            _database.Users.Remove(user);
            await _database.SaveChangesAsync();
        }

        public async Task<bool> HasUser(UserDTO userDTO)
        {
            User user = await _database.Users.FirstOrDefaultAsync(u => u.Login == userDTO.Login);
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<bool> IsUserNameTaken(string userName)
        {
            User user = await _database.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}