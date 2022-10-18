namespace Data.Helper
{
    using System.Net.Http.Headers;
    using System.Text;
    using Common.Models;
    using Data.Contracts;

    public static class HttpClientUtility
    {
        private const string ACCEPT_TYPE_KEY = "Accept";

        private const string JSON_SERIALIZER_VALUE = "application/json";

        private static MediaTypeWithQualityHeaderValue jsonTypeHeader = new MediaTypeWithQualityHeaderValue(JSON_SERIALIZER_VALUE);

        public static async Task<HttpResponseObject> MakeRequestAsync(
            HttpMethod httpMethod,
            string baseUri,
            string requestUri,
            object? requestContent = null,
            Dictionary<string, string>? headers = null,
            string contentType = "application/json",
            ICommonSerializer? serializer = null)
        {
            using var client = new HttpClient(new HttpClientHandler(), true);
            client.BaseAddress = new Uri(baseUri);
            var requestMessage = new HttpRequestMessage(method: httpMethod, requestUri: requestUri);
            requestMessage.Headers.Accept.Add(jsonTypeHeader);

            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    requestMessage.Headers.Add(key, value);
                }
            }

            if (requestContent != null)
            {
                serializer ??= new CommonJsonSerializer();
                requestMessage.Content = new StringContent(serializer.Serialize(requestContent), Encoding.UTF8, contentType);
                requestMessage.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue(contentType);
            }

            using var response = await client
                .SendAsync(requestMessage)
                .ConfigureAwait(false);

            return new HttpResponseObject
            {
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                JsonValue = (response.Content != null) ? 
                    await response.Content
                        .ReadAsStringAsync()
                        .ConfigureAwait(false) : 
                    null
            };
        }
    }
}
