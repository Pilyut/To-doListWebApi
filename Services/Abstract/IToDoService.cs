using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.ToDo;

namespace ToDoWebApi.Services
{
    public interface IToDoService
    {
        Task Add(ToDoClass list);
        Task Delete(int taskNum);
        Task Update(int taskNum, string str);
        Task MarkComplete(int taskNum);
        Task<List<ToDoClass>> GetAllAsync();
    }
}
