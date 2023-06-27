using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Utilities;

namespace TechnicalTest.iaps.Domain.Interfaces.Services
{
    public interface IPaperService
    {
        Task<List<PaperResponse>> Get();
        Task<PaperResponse> Get(string id);
        Task<PagedList<PaperResponse>> Get(GetQueryRequest request);
    }
}