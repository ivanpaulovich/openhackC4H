using System;
using Google.Cloud.Language.V1;

namespace openhackC4H
{
    class Program
    {
        static void Main(string[] args)
        {
            // The text to analyze.
            string text = "Software and system developers, gaming and digital media developers, system testers and test managers and system administrators.";
            var client = LanguageServiceClient.Create();
            var response = client.AnalyzeEntities(new Document()
            {
                Content = text,
                Type = Document.Types.Type.PlainText
            });
        
            Console.WriteLine($"Response: {response}");
        }
    }
}
