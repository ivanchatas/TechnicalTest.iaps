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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Category> _repository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Category>();
            _mapper = mapper;
        }

        public async Task<List<CategoryResponse>> Get()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryResponse>>(result.ToList());
        }

        public async Task<CategoryResponse> Get(int id)
        {
            var result = await _repository.GetFirstAsync(predicate: x => x.Id == id);
            return _mapper.Map<CategoryResponse>(result);
        }

        public async Task<PagedList<CategoryResponse>> Get(GetQueryRequest request)
        {
            var query = await _repository.GetAllAsync();

            if (!string.IsNullOrEmpty(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));

            if (request.SortOrder?.ToLower() == "desc")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(request));
            }

            var result = await PagedList<Category>.CreateAsync(query, request.Page, request.PageSize);
            var response = _mapper.Map<List<CategoryResponse>>(result.Items);
            return new PagedList<CategoryResponse>(response, result.Page, result.PageSize, result.TotalCount);
        }

        private static Expression<Func<Category, object>> GetSortProperty(GetQueryRequest request)
            => request.SortColumn?.ToLower() switch
            {
                "name" => category => category.Name,
                _ => category => category.Id
            };
    }
}
