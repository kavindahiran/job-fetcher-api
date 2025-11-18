using System.Reflection.PortableExecutable;

namespace JobFetcherAssesment.Models
{
    public class JobsDto
    {
        public int JobId { get; set; }
        public string JobName { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Priority { get; set; } = 1;
        public string Status { get; set; } = "Pending";
        public int? MachineId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public MachineDto? Machine { get; set; }
    }
}
