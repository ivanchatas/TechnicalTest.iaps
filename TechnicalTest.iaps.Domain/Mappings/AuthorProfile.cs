using AutoMapper;
using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Entities;

namespace TechnicalTest.iaps.Domain.Mappings
{
    internal class AuthorProfile : Profile
    { 
        public AuthorProfile()
        {
            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<AuthorAddRequest, Author>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name[0]))
                .ForMember(dest => dest.Initials, opt => opt.MapFrom(src => src.Name[1]))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Name[2]) ? null : src.Name[2]))
                .ReverseMap();
        }
    }
}
