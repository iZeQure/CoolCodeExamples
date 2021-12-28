using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using smartusing.example.LoggingExample;
using System.Net.Http;
using System.Net;

namespace smartusing.example
{
    public class SmartUsingExample
    {
        private readonly ILogger<SmartUsingExample> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public SmartUsingExample(ILogger<SmartUsingExample> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> RunExampleAsync()
        {
            var url = "https://randomuser.me/api/";
            var httpClient = _httpClientFactory.CreateClient();

            using var _ = _logger.TimedOperation(LogLevel.Information, "Retrieval of random user data");
            var response = await httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var rndData = await response.Content.ReadAsStringAsync();

            return rndData;
        }
    }
}
