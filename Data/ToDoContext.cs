using Microsoft.EntityFrameworkCore;
using Entities.ToDo;

namespace Data.DataBase
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
