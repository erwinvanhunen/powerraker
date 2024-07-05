using System.Data.SqlTypes;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PowerRaker.Utils
{
    internal static class RestHelper
    {
        public static string ExecuteGetRequest(RakerConnection connection, string endPoint)
        {
            return ExecuteRequest(connection, endPoint, HttpMethod.Get, null);
        }

        public static byte[] ExecuteGetRequestBinary(RakerConnection connection, string endPoint)
        {
            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;
            if (connection.IsTokenAuth())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connection.GetAuthToken());
            }
            var returnValue = client.GetByteArrayAsync(url).GetAwaiter().GetResult();
            return returnValue;
        }

        public static string ExecutePostRequest(RakerConnection connection, string endPoint, object payload)
        {
            return ExecuteRequest(connection, endPoint, HttpMethod.Post, payload);
        }

        public static string ExecuteDeleteRequest(RakerConnection connection, string endPoint, object payload)
        {
            return ExecuteRequest(connection, endPoint, HttpMethod.Delete, payload);
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
            if (connection.IsTokenAuth())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connection.GetAuthToken());
            }
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

        public static string ExecutePostMultiformData(RakerConnection connection, string endPoint, string fileName, byte[] data)
        {
            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;

            using (var content = new MultipartFormDataContent("FormBoundary1"))
            {
                var streamContent = new StreamContent(new MemoryStream(data));
                content.Add(streamContent, "file", fileName);

                if (connection.IsTokenAuth())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connection.GetAuthToken());
                }

                var responseMessage = client.PostAsync(url, content).GetAwaiter().GetResult();
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
}