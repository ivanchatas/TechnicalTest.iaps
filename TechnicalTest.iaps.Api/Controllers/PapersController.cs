using Microsoft.AspNetCore.Mvc;
using TechnicalTest.iaps.Domain.DtoModels.Requests;
using TechnicalTest.iaps.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTest.iaps.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PapersController : ControllerBase
    {
        private readonly IPaperService _paperService;

        public PapersController(IPaperService paperService) 
        {
            _paperService = paperService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _paperService.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
            => Ok(await _paperService.Get(id));    
        
        [HttpGet("search")]
        public async Task<IActionResult> Get([FromQuery] GetQueryRequest request)
            => Ok(await _paperService.Get(request));
    }
}
