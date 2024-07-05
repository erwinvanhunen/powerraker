using System.Data.SqlTypes;
using System.Management.Automation;
using System.Security.Policy;
using System.Text.Json;
using PowerRaker.Utils;

namespace PowerRaker
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

        internal T? GetResult<T>(string url)
        {
            var output = RestHelper.ExecuteGetRequest(Connection, url);
            var result = JsonSerializer.Deserialize<Model.RequestResult<T>>(output, JsonSerializerOptions);
            if (result != null)
            {
                return result.Result;
            }
            else
            {
                return default;
            }
        }

        internal byte[] GetBinaryResult(string url)
        {
            var bytes = RestHelper.ExecuteGetRequestBinary(Connection, url);
            return bytes;
        }

        internal T? PostResult<T>(string url, object? payload = null)
        {
            var output = RestHelper.ExecutePostRequest(Connection, url, payload);
            var result = JsonSerializer.Deserialize<Model.RequestResult<T>>(output, JsonSerializerOptions);
            if (result != null)
            {
                return result.Result;
            }
            else
            {
                return default;
            }
        }


        internal T? PostMultiformData<T>(string Url, string fileName, byte[] data)
        {
            var output = RestHelper.ExecutePostMultiformData(Connection, Url, fileName, data);
            var result = JsonSerializer.Deserialize<Model.RequestResult<T>>(output, JsonSerializerOptions);

            if (result != null)
            {
                return result.Result;
            }
            else
            {
                return default;
            }

        }

        internal T? DeleteResult<T>(string url, object? payload = null)
        {
            var output = RestHelper.ExecuteDeleteRequest(Connection, url, payload);
            var result = JsonSerializer.Deserialize<Model.RequestResult<T>>(output, JsonSerializerOptions);

            if (result != null)
            {
                return result.Result;
            }
            else
            {
                return default;
            }
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