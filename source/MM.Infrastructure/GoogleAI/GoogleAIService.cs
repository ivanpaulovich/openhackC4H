using System.Collections.Generic;
using MM.Domain.Services;
using Google.Cloud.Language.V1;

namespace MM.Infrastructure.GoogleAI
{
    public class GoogleAIService : IGoogleAIService
    {
        private readonly Google.Cloud.Language.V1.LanguageServiceClient _client;

        public GoogleAIService()
        {
            _client = LanguageServiceClient.Create();
        }

        public List<string> GetCategories(string body)
        {
            var response = _client.ClassifyText(new Document()
            {
                Content = body,
                Type = Document.Types.Type.PlainText
            });

            List<string> categories = new List<string>();

            foreach(var cat in response.Categories)
            {
                categories.Add(cat.Name);
            }

            return categories;
        }
    }
}