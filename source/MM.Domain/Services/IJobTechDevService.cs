namespace MM.Domain.Services
{
    using System.Threading.Tasks;

    public interface IJobTechDevService
    {
        Task<Job> GetJob(int jobId);
    }
}