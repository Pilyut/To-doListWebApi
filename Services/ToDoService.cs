using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTO;
using AutoMapper;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _database;
        private readonly IMapper _mapper;

        public ToDoService(ToDoContext database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<List<ToDoDTO>> GetAllAsync(int id)
        {
            List<ToDoDTO> listDTO = new();
            var list = await _database.Tasks.Where(p => p.UserId == id).ToListAsync();
            foreach (var task in list)
            {
                var todo = _mapper.Map<ToDoDTO>(task);
                listDTO.Add(todo);
            }
            return listDTO;
        }

        public async Task Add(ToDoDTO taskDTO, int userId)
        {
            var task = _mapper.Map<ToDo>(taskDTO);
            task.UserId = userId;
            await _database.Tasks.AddAsync(task);
            await _database.SaveChangesAsync();
        }

        public async Task Update(ToDoDTO toDoDTO, int userId)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(x => x.UserId == userId);
            task.Task = toDoDTO.Task;
            _database.Tasks.Update(task);
            await _database.SaveChangesAsync();
        }

        public async Task MarkComplete(int userId)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(p => p.UserId == userId);
            task.Status = true;
            await _database.SaveChangesAsync();
        }

        public async Task Delete(int todoId)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(x => x.Id == todoId);
            _database.Tasks.Remove(task);
            await _database.SaveChangesAsync();
        }

        

        
    }
}
