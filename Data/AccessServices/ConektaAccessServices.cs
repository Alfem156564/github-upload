namespace Data.AccessServices
{
    using Common.Models;
    using Common.Models.Conekta;
    using Data.Contracts;
    using Data.Helper;

    public class ConektaAccessServices : IConektaAccessServices
    {
        private string conektaBasicUrl = "https://api.conekta.io/";
        private string key = "key_iBa7DrAlkHdYpeKBy7OiE4t";
        private string base64key = "";

        private readonly ICommonSerializer _serializer;

        public ConektaAccessServices(ICommonSerializer serializer)
        {
            this._serializer = serializer;
            this.base64key = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(key));
        }

        public async Task<ManagerResult<ConektaClienteModel>> PostCliente(ConektaCreateClienteModel model)
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Authorization", $"Basic {base64key}");
            headers.Add("Accept", $"application/vnd.conekta-v2.0.0+json");

            var response = await HttpClientUtility
                .MakeRequestAsync(
                    httpMethod: HttpMethod.Post,
                    baseUri: conektaBasicUrl,
                    requestUri: $"customers",
                    requestContent: model,
                    headers: headers)
                .ConfigureAwait(continueOnCapturedContext: false);

            if (response.IsSuccessStatusCode)
            {
                var value = _serializer.Deserialize<ConektaClienteModel>(response.JsonValue);
                return ManagerResult<ConektaClienteModel>.FromSuccess(value);
            }
            else
            {
                var value = _serializer.Deserialize<ConektaErrorModel>(response.JsonValue);
                return ManagerResult<ConektaClienteModel>.FromErrorValue(value);
            }
        }

        public async Task<ManagerResult<ConektaClienteModel>> GetCliente(string customerId)
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Authorization", $"Basic {base64key}");
            headers.Add("Accept", $"application/vnd.conekta-v2.0.0+json");

            var response = await HttpClientUtility
                .MakeRequestAsync(
                    httpMethod: HttpMethod.Get,
                    baseUri: conektaBasicUrl,
                    requestUri: $"customers/{customerId}",
                    headers: headers)
                .ConfigureAwait(continueOnCapturedContext: false);

            if (response.IsSuccessStatusCode)
            {
                var value = _serializer.Deserialize<ConektaClienteModel>(response.JsonValue);
                return ManagerResult<ConektaClienteModel>.FromSuccess(value);
            }
            else
            {
                var value = _serializer.Deserialize<ConektaErrorModel>(response.JsonValue);
                return ManagerResult<ConektaClienteModel>.FromErrorValue(value);
            }
        }

        public async Task<ManagerResult<ConektaTokenResponseModel>> PostToken(ConektaSearchTokenModel model)
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Authorization", $"Basic {base64key}");
            headers.Add("Accept", $"application/vnd.conekta-v2.0.0+json");

            var response = await HttpClientUtility
                .MakeRequestAsync(
                    httpMethod: HttpMethod.Post,
                    baseUri: conektaBasicUrl,
                    requestUri: $"tokens",
                    requestContent: model,
                    headers: headers)
                .ConfigureAwait(continueOnCapturedContext: false);

            if (response.IsSuccessStatusCode)
            {
                var value = _serializer.Deserialize<ConektaTokenResponseModel>(response.JsonValue);
                return ManagerResult<ConektaTokenResponseModel>.FromSuccess(value);
            }
            else
            {
                var value = _serializer.Deserialize<ConektaErrorModel>(response.JsonValue);
                return ManagerResult<ConektaTokenResponseModel>.FromErrorValue(value);
            }
        }

        public async Task<ManagerResult<ConektaCardResponseModel>> PostCard(string customerId, ConektaCreateCardModel model)
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Authorization", $"Basic {base64key}");
            headers.Add("Accept", $"application/vnd.conekta-v2.0.0+json");

            var response = await HttpClientUtility
                .MakeRequestAsync(
                    httpMethod: HttpMethod.Post,
                    baseUri: conektaBasicUrl,
                    requestUri: $"customers/{customerId}/payment_sources",
                    requestContent: model,
                    headers: headers)
                .ConfigureAwait(continueOnCapturedContext: false);

            if (response.IsSuccessStatusCode)
            {
                var value = _serializer.Deserialize<ConektaCardResponseModel>(response.JsonValue);
                return ManagerResult<ConektaCardResponseModel>.FromSuccess(value);
            }
            else
            {
                var value = _serializer.Deserialize<ConektaErrorModel>(response.JsonValue);
                return ManagerResult<ConektaCardResponseModel>.FromErrorValue(value);
            }
        }

        public async Task<ManagerResult<ConektaOrderResponseModel>> PostOrder(ConektaOrderModel model)
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Authorization", $"Basic {base64key}");
            headers.Add("Accept", $"application/vnd.conekta-v2.0.0+json");

            var response = await HttpClientUtility
                .MakeRequestAsync(
                    httpMethod: HttpMethod.Post,
                    baseUri: conektaBasicUrl,
                    requestUri: $"orders",
                    requestContent: model,
                    headers: headers)
                .ConfigureAwait(continueOnCapturedContext: false);

            if (response.IsSuccessStatusCode)
            {
                var value = _serializer.Deserialize<ConektaOrderResponseModel>(response.JsonValue);
                return ManagerResult<ConektaOrderResponseModel>.FromSuccess(value);
            }
            else
            {
                var value = _serializer.Deserialize<ConektaErrorModel>(response.JsonValue);
                return ManagerResult<ConektaOrderResponseModel>.FromErrorValue(value);
            }
        }
    }
}
