using System;
using AutoMapper;
using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Entities.Concrete;

namespace AnimalHealthApp.Services.AutoMapper.Profiles
{
    public class VeterinaryClinicProfile : Profile
    {
        public VeterinaryClinicProfile()
        {
            CreateMap<VeterinaryClinicAddDto, VeterinaryClinic>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<VeterinaryClinicUpdateDto, VeterinaryClinic>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<VeterinaryClinic, VeterinaryClinicUpdateDto>();
        }
    }
}
