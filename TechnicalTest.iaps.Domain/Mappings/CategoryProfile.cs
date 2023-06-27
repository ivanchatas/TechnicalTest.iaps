using AutoMapper;
using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.Entities;

namespace TechnicalTest.iaps.Domain.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponse>().ReverseMap();
        }
    }
}
