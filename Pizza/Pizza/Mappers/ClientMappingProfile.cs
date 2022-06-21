using AutoMapper;

namespace Pizza.API.Mappers
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Pizza.Data.Interface.Model.Pizza, Pizza.Domain.Interface.Models.Pizza>()             
              .ReverseMap();
            CreateMap<Pizza.API.Models.Pizza, Pizza.Domain.Interface.Models.Pizza>()
             .ReverseMap();
        }
    }
}
