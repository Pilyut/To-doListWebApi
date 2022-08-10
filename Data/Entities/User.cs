using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<ToDo> ToDo { get; set; } = new();
    }
}