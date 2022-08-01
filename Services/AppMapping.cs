using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public class AppMapping : Profile
    {
        public AppMapping()
        {
            CreateMap<ToDo, ToDoDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
