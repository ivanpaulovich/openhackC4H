using System.Collections.Generic;

namespace MM.Domain.Services
{
    public interface IGoogleAIService
    {
        List<string> GetCategories(string body);
    }
}