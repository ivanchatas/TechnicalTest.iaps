using AutoMapper;
using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Entities;

namespace TechnicalTest.iaps.Domain.Mappings
{
    public class PaperProfile : Profile
    {
        public PaperProfile()
        {
            CreateMap<Paper, PaperResponse>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => string.Join(",", src.Authors.Select(x => $"{x.LastName} {x.Name}"))))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => string.Join(",", src.Categories.Select(x => $"{x.Name}"))))
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.UpdateDate))
                .ReverseMap();

            CreateMap<PaperAddRequest, Paper>().ReverseMap();
        }
    }
}
