using AutoMapper;
using System.Linq.Expressions;
using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Entities;
using TechnicalTest.iaps.Domain.Interfaces.Repositories;
using TechnicalTest.iaps.Domain.Interfaces.Services;
using TechnicalTest.iaps.Domain.Utilities;

namespace TechnicalTest.iaps.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Author> _repository;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Author>();
            _mapper = mapper;
        }

        public async Task<List<AuthorResponse>> Get()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<AuthorResponse>>(result.ToList());
        }

        public async Task<AuthorResponse> Get(int id)
        {
            var result = await _repository.GetFirstAsync(predicate: x => x.Id == id);
            return _mapper.Map<AuthorResponse>(result);
        }

        public async Task<PagedList<AuthorResponse>> Get(GetQueryRequest request)
        {
            var query = await _repository.GetAllAsync();

            if (!string.IsNullOrEmpty(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm) || x.LastName.Contains(request.SearchTerm));

            if (request.SortOrder?.ToLower() == "desc")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(request));
            }

            var result = await PagedList<Author>.CreateAsync(query, request.Page, request.PageSize);
            var response = _mapper.Map<List<AuthorResponse>>(result.Items);
            return new PagedList<AuthorResponse>(response, result.Page, result.PageSize, result.TotalCount);
        }

        private static Expression<Func<Author, object>> GetSortProperty(GetQueryRequest request)
            => request.SortColumn?.ToLower() switch
            {
                "name" => author => author.Name,
                "lastName" => author => author.LastName,
                _ => category => category.Id
            };
    }
}
