using JobFetcherAssesment.Interfaces;
using JobFetcherAssesment.Models;

namespace JobFetcherAssesment.Business
{
    public class JobsService: IJobService
    {
        private readonly IJobRepository _repo;
        public JobsService(IJobRepository repo)
        {
            _repo = repo;
        }
        public Task<JobsDto?> GetByIdAsync(int id) => _repo.GetJobsByIdAsync(id);
        public Task<IEnumerable<JobsDto>> GetAllAsync(int page, int pageSize) => _repo.GetAllJobsAsync(page, pageSize);
    }
}
