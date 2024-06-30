using System.Text.Json;

namespace powerraker
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
                var error = jsonDocument.RootElement.GetProperty("error").Deserialize<Error>(options);
                throw new Exception(error.Message);
            }
        }

        public static byte[] ExecuteGetRequestBinary(RakerConnection connection, string endPoint)
        {
            var url = connection.Printer + endPoint;

            var client = connection.HttpClient;
            var returnValue = client.GetByteArrayAsync(url).GetAwaiter().GetResult();
            return returnValue;
        }

        // public static HttpResponseMessage ExecutePostRequest(ClientContext context, string endPointUrl, string content, string select = null, string filter = null, string expand = null, Dictionary<string, string> additionalHeaders = null, string contentType = "application/json", uint? top = null)
        // {
        //     HttpContent stringContent = null;
        //     if (!string.IsNullOrEmpty(content))
        //     {
        //         stringContent = new StringContent(content);
        //     }
        //     if (stringContent != null && contentType != null)
        //     {
        //         stringContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType);
        //     }
        //     return ExecutePostRequestInternal(context, endPointUrl, stringContent, select, filter, expand, additionalHeaders, top);
        // }

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
                var error = jsonDocument.RootElement.GetProperty("error").Deserialize<Error>(options);
                throw new Exception(error.Message);
            }
        }
    }
}