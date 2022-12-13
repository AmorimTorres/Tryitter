using AutoMapper;
using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.DTOS.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
