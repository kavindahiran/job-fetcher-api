namespace JobFetcherAssesment.Models
{
    public class MachineDto
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? Capacity { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<JobsDto>? Jobs { get; set; }
    }
}
