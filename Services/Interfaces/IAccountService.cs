using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        public Task Register(RegisterModel model);
        public Task Login(LoginModel model);
        public Task Logout();
    }
}
