using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer
{
    public interface IToDoService
    {
        Task Add(ToDoDTO list);
        Task Delete(int taskNum);
        Task Update(int taskNum, string str);
        Task MarkComplete(int taskNum);
        Task<List<ToDoDTO>> GetAllAsync();
    }
}
