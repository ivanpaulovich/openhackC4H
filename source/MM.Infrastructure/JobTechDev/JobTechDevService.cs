using System.Net.Http;
using System.Threading.Tasks;
using MM.Domain;
using MM.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MM.Infrastructure.JobTechDev
{
    public class JobTechDevService : IJobTechDevService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public JobTechDevService(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json;charset=utf-8; qs=1");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en");
        }

        public async Task<Job> GetJob(int jobId)
        {
      
            HttpResponseMessage response = await _httpClient.GetAsync("/af/v0/platsannonser/" + jobId);
            if (response.IsSuccessStatusCode)
            {
                string job = await response.Content.ReadAsStringAsync();
                dynamic jObject = JsonConvert.DeserializeObject<dynamic>(job);
                string body = jObject.platsannons.annons.annonstext;
                string title = jObject.platsannons.annons.annonsrubrik;
                
                return new Job() {
                    Id = jobId,
                    Title = title,
                    Body = body
                };

            }

            throw new System.Exception($"Job {jobId} not found.");
        }
    }
}