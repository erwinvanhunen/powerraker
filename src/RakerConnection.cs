using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PowerRaker.Model.Users;
using PowerRaker.Utils;

namespace PowerRaker
{

    public class RakerConnection
    {
        private HttpClient? httpClient;

        public string Printer { get; internal set; }
        public string? APIKey { get; internal set; }

        private string? Username;
        private SecureString? Password;
        private string? Token;
        private string? RefreshToken;
        private DateTime TokenExpires;


        public RakerConnection(string printer, string? APIKey)
        {
            this.Printer = printer;
            this.APIKey = APIKey;
            this.Token = null;
            Current = this;
        }

        public RakerConnection(string printer, string? username, SecureString? password, string? source)
        {

            this.Printer = printer;
            this.Username = username;
            this.Password = password;

            var output = RestHelper.ExecutePostRequest(this, "/access/login", new { username = username, password = GetPlainPassword(password), source = source });
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            var result = JsonSerializer.Deserialize<Model.RequestResult<AuthInfo>>(output, options);
            this.Token = result.Result.Token;
            this.RefreshToken = result.Result.RefreshToken;
            this.TokenExpires = DateTime.Now.AddHours(1);
            Current = this;
        }

        private static string GetPlainPassword(SecureString password)
        {
            return new System.Net.NetworkCredential("", password).Password;
        }

        public bool IsTokenAuth()
        {
            return this.Token != null;
        }

        public string GetAuthToken()
        {
            if (this.Token == null || DateTime.Now > TokenExpires)
            {
                GetRefreshToken(this.RefreshToken);
            }
            return this.Token;
        }

        private void GetRefreshToken(string refreshToken)
        {
            var output = ExecuteRequest(this, "/access/refresh_jwt", HttpMethod.Post, new { refresh_token = refreshToken });
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            var result = JsonSerializer.Deserialize<Model.RequestResult<AuthInfo>>(output, options);
            this.Token = result.Result.Token;
            this.TokenExpires = DateTime.Now.AddHours(1);
        }

        public static RakerConnection? Current
        {
            get; internal set;
        }

        public HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    if (APIKey != null)
                    {
                        httpClient.DefaultRequestHeaders.Add("X-Api-Key", APIKey);
                    }
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }
                return httpClient;
            }
        }

        private static string ExecuteRequest(RakerConnection connection, string endPoint, HttpMethod method, object? payload)
        {
            StringContent? content = null;
            if (payload != null)
            {
                content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            }

            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;

            var httpRequestMessage = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            var responseMessage = client.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            else
            {
                var response = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                };
                var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(response);
                if (jsonDocument != null)
                {
                    var error = jsonDocument.RootElement.GetProperty("error").Deserialize<Error>(options);
                    throw new Exception(error?.Message);
                }
                else
                {
                    throw new HttpRequestException(responseMessage.ReasonPhrase, new Exception("Request failed"), responseMessage.StatusCode);
                }
            }
        }
    }
}