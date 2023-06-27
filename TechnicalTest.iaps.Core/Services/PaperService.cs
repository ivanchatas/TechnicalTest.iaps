using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechnicalTest.iaps.Domain.DtoModels.Reponses;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Entities;
using TechnicalTest.iaps.Domain.Interfaces.Repositories;
using TechnicalTest.iaps.Domain.Interfaces.Services;
using TechnicalTest.iaps.Domain.Utilities;

namespace TechnicalTest.iaps.Core.Services
{
    public class PaperService : IPaperService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Paper> _repository;

        public PaperService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Paper>();
            _mapper = mapper;
        }

        public async Task<List<PaperResponse>> Get()
        {
            var result = await _repository.GetAllAsync(include: x => x.Include(y => y.Authors).Include(y => y.Categories));
            return _mapper.Map<List<PaperResponse>>(result.ToList());
        }

        public async Task<PaperResponse> Get(string id)
        {
            var result = await _repository.GetFirstAsync(predicate: x => x.Id == id);
            return _mapper.Map<PaperResponse>(result);
        }

        public async Task<PagedList<PaperResponse>> Get(GetQueryRequest request) 
        {
            var query = await _repository.GetAllAsync(include: x => x.Include(y => y.Authors).Include(y => y.Categories));

            if (!string.IsNullOrEmpty(request.SearchTerm)) 
            {
                query = query.Where(x => x.Title.Contains(request.SearchTerm) ||
                                         x.Abstract.Contains(request.SearchTerm) ||
                                         x.Authors.Any(y => y.Name.Contains(request.SearchTerm) ||
                                                            y.LastName.Contains(request.SearchTerm)) ||
                                         x.Categories.Any(y => y.Name.Contains(request.SearchTerm)));
            }

            if (request.SortOrder?.ToLower() == "desc")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else 
            {
                query = query.OrderBy(GetSortProperty(request));
            }

            var result = await PagedList<Paper>.CreateAsync(query, request.Page, request.PageSize);
            var response = _mapper.Map<List<PaperResponse>>(result.Items);
            return new PagedList<PaperResponse>(response, result.Page, result.PageSize, result.TotalCount);
        }

        private static Expression<Func<Paper, object>> GetSortProperty(GetQueryRequest request)
            => request.SortColumn?.ToLower() switch
            {
                "title" => paper => paper.Title,
                "abstract" => paper => paper.Abstract,
                _ => paper => paper.Id
            };
    }
}
