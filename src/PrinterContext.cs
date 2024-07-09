using System.Security;
using System.Text;
using System.Text.Json;
using PowerRaker.Model.Users;
using PowerRaker.Utils;

namespace PowerRaker
{

    public class PrinterContext
    {
        private HttpClient? httpClient;

        public string Printer { get; internal set; }
        public string? APIKey { get; internal set; }

        public string? Username { get; set; }
        private SecureString? Password;
        private string? Token;
        private string? RefreshToken;
        public DateTime TokenExpires {get; internal set;}


        public PrinterContext(string printer, string? APIKey)
        {
            this.Printer = printer;
            this.APIKey = APIKey;
            this.Token = null;
            Current = this;
        }

        public PrinterContext(string printer, string? username, SecureString? password, string? source)
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

        public string? GetAuthToken()
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

        public static PrinterContext? Current
        {
            get; internal set;
        }

        internal HttpClient HttpClient
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

        private static string ExecuteRequest(PrinterContext connection, string endPoint, HttpMethod method, object? payload)
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