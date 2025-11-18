using JobFetcherAssesment.Models;

namespace JobFetcherAssesment.Interfaces
{
    public interface IJobService
    {
        Task<JobsDto?> GetByIdAsync(int id);
        Task<IEnumerable<JobsDto>> GetAllAsync(int page, int pageSize);
    }
}
