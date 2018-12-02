using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM.Domain.Services
{
    public interface IJobsToEmojiService
    {
         Task<List<Job>> SearchJobs(string keyword);
    }
}