using Microsoft.AspNetCore.Mvc;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTest.iaps.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService) 
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _authorService.Get());

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await _authorService.Get(id));

        [HttpGet("search")]
        public async Task<IActionResult> Get([FromQuery] GetQueryRequest request)
            => Ok(await _authorService.Get(request));
    }
}
