using JobFetcherAssesment.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobFetcherAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _service;
        public JobsController(IJobService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllJobs([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var list = await _service.GetAllAsync(page, pageSize);
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _service.GetByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }
    }
}
