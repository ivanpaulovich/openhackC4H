namespace MM.Tests
{
    using Xunit;
    using MM.Domain.Services;
    using MM.Domain;
    using MM.Infrastructure.JobTechDev;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public sealed class JobTechDevTests
    {
        [Fact]
        public void GetJobById_ReturnsSingleJob()
        {
            // Arrange

            string baseUrl = "https://api.arbetsformedlingen.se";
            IJobTechDevService jobTechDevService = new JobTechDevService(baseUrl);
            int expectedJobId = 8047923;

            // Act
            Job job = jobTechDevService.GetJob(expectedJobId).Result;

            // Assert
            Assert.Equal(expectedJobId, job.Id);
            Assert.NotEmpty(job.Title);
            Assert.NotEmpty(job.Body);
        }

        [Fact]
        public void GetJobsByKeyword_ReturnsJobs()
        {
            // Arrange

            string baseUrl = "https://api.arbetsformedlingen.se";
            IJobTechDevService jobTechDevService = new JobTechDevService(baseUrl);
            string keyword = "javascript";

            // Act
            List<Job> jobs = jobTechDevService.SearchJobs(keyword).Result;

            // Assert
            Assert.NotNull(jobs);
            Assert.NotEmpty(jobs);
        }
    }
}