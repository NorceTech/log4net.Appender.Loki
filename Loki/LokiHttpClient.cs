using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Log4Net.Appender.Loki
{
    public class LokiHttpClient
    {
        private static readonly HttpClient httpClient = HttpClientSingleton.Instance.HttpClient;

        public void SetAuthCredentials(LokiCredentials credentials)
        {
            if (!(credentials is BasicAuthCredentials c))
                return;

            var headers = httpClient.DefaultRequestHeaders;
            if (headers.Any(x => x.Key == "Authorization"))
                return;

            var token = Base64Encode($"{c.Username}:{c.Password}");
            headers.Add("Authorization", $"Basic {token}");
        }

        public virtual Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            return httpClient.PostAsync(requestUri, content);
        }

        public virtual void Dispose()
            => httpClient.Dispose();

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}