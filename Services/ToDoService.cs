using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.DataBase;
using Entities.ToDo;
using ToDoWebApi.Services;

namespace Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _database;
        public ToDoService(ToDoContext database)
        {
            _database = database;
        }
        public async Task Add(ToDoClass list)
        {
            await _database.Tasks.AddAsync(list);
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
        public async Task<List<ToDoClass>> GetAllAsync()
        {
            return await _database.Tasks.ToListAsync();
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
