using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Utilities;

namespace TechnicalTest.iaps.Domain.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorResponse>> Get();
        Task<AuthorResponse> Get(int id);
        Task<PagedList<AuthorResponse>> Get(GetQueryRequest request);
    }
}
