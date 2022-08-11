using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Interfaces
{
    public interface IToDoService
    {
        Task<List<ToDoDTO>> GetAllAsync(int id);
        Task Add(ToDoDTO taskDTO, int userId);
        Task Update(ToDoDTO toDoDTO, int userId);
        Task MarkComplete(int userId);
        Task Delete(int todoId);
    }
}
