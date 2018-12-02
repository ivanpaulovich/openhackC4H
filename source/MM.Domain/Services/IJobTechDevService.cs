namespace MM.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJobTechDevService
    {
        Task<Job> GetJob(int jobId);
        Task<List<Job>> SearchJobs(string keyword);
    }
}