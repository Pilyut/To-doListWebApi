using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTO;
using AutoMapper;

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
        public async Task Add(ToDoDTO list)
        {
            var task = _mapper.Map<ToDo>(list);
            await _database.Tasks.AddAsync(task);
            await _database.SaveChangesAsync();
        }
        public async Task Delete(int taskId)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);

            if (task == null)
            {
                throw new Exception("Delete don't work");
            }
            _database.Tasks.Remove(task);
            await _database.SaveChangesAsync();
        }
        public async Task Update(int taskId, string str)
        {
            var task = await _database.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);

            if (task == null)
            {
                throw new Exception("Update don't work");
            }
            task.Task = str;
            task.Status = false;
            _database.Tasks.Update(task);
            await _database.SaveChangesAsync();
        }
        public async Task MarkComplete(int taskId)
        {
            var task = await _database.Tasks.FindAsync(taskId);

            if (task == null)
            {
                throw new Exception("Mark don't work");
            }
            task.Status = true;
            await _database.SaveChangesAsync();
        }
        public async Task<List<ToDoDTO>> GetAllAsync()
        {
            List<ToDoDTO> List = new List<ToDoDTO>();
            var list = await _database.Tasks.ToListAsync();
            foreach (var task in list)
            {
                var todo = _mapper.Map<ToDoDTO>(task);
                List.Add(todo);
            }
            return List;
        }
        public bool HasElement()
        {
            return _database.Tasks.Any();
        }
        public bool CheckCount(int s)
        {
            return _database.Tasks.Count() >= s;
        }
    }
}
