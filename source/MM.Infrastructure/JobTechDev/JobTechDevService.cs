using System.Net.Http;
using System.Threading.Tasks;
using MM.Domain;
using MM.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;

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

        public async Task<List<Job>> SearchJobs(string keyword)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/af/v0/platsannonser/matchning?nyckelord={keyword}&sida=1&antalrader=20");
            if (response.IsSuccessStatusCode)
            {
                string jobs = await response.Content.ReadAsStringAsync();
                dynamic jObject = JsonConvert.DeserializeObject<dynamic>(jobs);
                dynamic jobsJson = jObject.matchningslista.matchningdata;
                
                List<Job> result = new List<Job>();

                foreach(dynamic jobJson in jobsJson)
                {
                    var loadedJob = await GetJob(System.Convert.ToInt32(jobJson.annonsid));
                    result.Add(loadedJob);
                }
                
                return result;
            }

            throw new System.Exception($"Search error.");
        }
    }
}