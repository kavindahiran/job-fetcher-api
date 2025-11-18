using JobFetcherAssesment.Models;

namespace JobFetcherAssesment.Interfaces
{
    public interface IJobRepository
    {   
        Task<JobsDto?> GetJobsByIdAsync(int id);
        Task<IEnumerable<JobsDto>> GetAllJobsAsync(int page = 1, int pageSize = 50);
        //Task<int> InsertJobAsync(JobsDto jobs);
    }
}
