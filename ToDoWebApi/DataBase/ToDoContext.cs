using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoWebApi.DataBase
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoClass> Tasks { get; set; } = null!;
        public ToDoContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./../../../ToDoDataBase.db");
        }
    }
}
