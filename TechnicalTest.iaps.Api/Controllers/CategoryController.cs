using Microsoft.AspNetCore.Mvc;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTest.iaps.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _categoryService.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await _categoryService.Get(id));

        [HttpGet("search")]
        public async Task<IActionResult> Get([FromQuery] GetQueryRequest request)
            => Ok(await _categoryService.Get(request));
    }
}
