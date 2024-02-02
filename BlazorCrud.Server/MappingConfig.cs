using AutoMapper;
using BlazorCrud.Server.Models.Entidades;
using BlazorCrud.Shared;

namespace BlazorCrud.Server
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        { 
            CreateMap<Personal, PersonalDTO>().ReverseMap();
            CreateMap<RangoPersonal, RangoPersonalDTO>().ReverseMap();
        }
    }
}
