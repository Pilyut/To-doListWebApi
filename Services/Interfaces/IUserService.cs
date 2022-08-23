using BusinessLogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        public Task AddUser(UserDTO userDTO);
        public Task DeleteUser(int id);
        public Task UpdateUserName(int id, string newUserName);
        public Task<List<UserDTO>> GetUserList();
        public Task<bool> HasUser(UserDTO userDTO);
    }
}
