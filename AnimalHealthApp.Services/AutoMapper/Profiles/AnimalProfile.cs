using System;
using AutoMapper;
using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Entities.Concrete;

namespace AnimalHealthApp.Services.AutoMapper.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<AnimalAddDto, Animal>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<AnimalUpdateDto, Animal>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
