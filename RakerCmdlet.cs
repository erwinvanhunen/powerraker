using System.Management.Automation;
using System.Text.Json;

namespace powerraker
{
    public abstract class RakerCmdlet : PSCmdlet
    {
        internal JsonSerializerOptions JsonSerializerOptions
        {
            get
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = this.JsonNamingPolicy
                };
                options.Converters.Add(new UnixToNullableDateTimeConverter());
                return options;
            }
        }
        internal JsonNamingPolicy JsonNamingPolicy => JsonNamingPolicy.SnakeCaseLower;

        public RakerConnection Connection
        {
            get
            {
                if (RakerConnection.Current != null)
                { return RakerConnection.Current; }
                else
                {
                    throw new Exception("No connection.");
                }
            }
        }

        protected virtual void ExecuteCmdlet()
        { }

        internal JsonElement GetResult(string url, string? collectionName = null)
        {
            var output = RestHelper.ExecuteGetRequest(Connection, url);

            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output);
            if (jsonDocument != null)
            {
                if (collectionName != null)
                {
                    return jsonDocument.RootElement.GetProperty("result").GetProperty(collectionName);
                }
                else
                {
                    return jsonDocument.RootElement.GetProperty("result");
                }
            }
            else
            {
                return new JsonElement();
            }
        }

        internal JsonElement PostResult(string url, object? payload = null)
        {
         
            var output = RestHelper.ExecutePostRequest(Connection, url);
         
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output);
            if (jsonDocument != null)
            {

                return jsonDocument.RootElement.GetProperty("result");

            }
            else
            {
                return new JsonElement();
            }
        }

        internal T? GetResult<T>(string url, string? collectionName = null)
        {
            var result = GetResult(url, collectionName);
            return JsonSerializer.Deserialize<T>(result, JsonSerializerOptions);
        }

        internal T? PostResult<T>(string url, object? payload = null)
        {
            var result = PostResult(url, payload);
            return JsonSerializer.Deserialize<T>(result, JsonSerializerOptions);
        }

        protected override void ProcessRecord()
        {
            try
            {
                if (this.Connection != null)
                {
                    ExecuteCmdlet();
                }
                else
                {
                    throw new Exception("No connection.");
                }
            }
            catch (Exception ex)
            {
                throw new PSInvalidOperationException(ex.Message);
            }
        }

    }
}