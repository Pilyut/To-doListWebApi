using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EF
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> Tasks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null;
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
