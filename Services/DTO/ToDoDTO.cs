using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTO
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}