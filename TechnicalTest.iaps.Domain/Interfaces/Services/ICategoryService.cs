using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Utilities;

namespace TechnicalTest.iaps.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> Get();
        Task<CategoryResponse> Get(int id);
        Task<PagedList<CategoryResponse>> Get(GetQueryRequest request);
    }
}
