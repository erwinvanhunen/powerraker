using System.Data.SqlTypes;
using System.Diagnostics;
using System.Text.Json;

namespace PowerRaker
{
    internal static class RestHelper
    {
        public static string ExecuteGetRequest(RakerConnection connection, string endPoint)
        {
            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;
            var responseMessage = client.GetAsync(url).GetAwaiter().GetResult();
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

        public static string ExecuteDeleteRequest(RakerConnection connection, string endPoint)
        {
            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;
            var responseMessage = client.DeleteAsync(url).GetAwaiter().GetResult();
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

        public static byte[] ExecuteGetRequestBinary(RakerConnection connection, string endPoint)
        {
            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;
            var returnValue = client.GetByteArrayAsync(url).GetAwaiter().GetResult();
            return returnValue;
        }

        public static string ExecutePostRequest(RakerConnection connection, string endPoint)
        {

            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;
            var responseMessage = client.PostAsync(url, null).GetAwaiter().GetResult();
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