namespace MM.Tests
{
    using Xunit;
    using MM.Domain.Services;
    using MM.Domain;
    using MM.Infrastructure.JobTechDev;
    using System.Threading.Tasks;

    public sealed class JobToEmojiTests
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
    }
}