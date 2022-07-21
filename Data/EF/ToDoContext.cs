using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EF
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> Tasks { get; set; } = null!;
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
