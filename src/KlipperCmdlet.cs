using System.Management.Automation;
using System.Text.Json;
using PowerRaker.Utils;

namespace PowerRaker
{
    public abstract class KlipperCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = false)]
        public PrinterContext? Connection { get; set; }

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

        public PrinterContext Context
        {
            get
            {
                if (this.Connection != null)
                {
                    return this.Connection;
                }
                else
                {
                    if (PrinterContext.Current != null)
                    { return PrinterContext.Current; }
                    else
                    {
                        throw new Exception("No connection.");
                    }
                }
            }
        }

        protected virtual void ExecuteCmdlet()
        { }

        internal T? GetResult<T>(string url)
        {
            var output = RestHelper.ExecuteGetRequest(Context, url);
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
            var bytes = RestHelper.ExecuteGetRequestBinary(Context, url);
            return bytes;
        }

        internal T? PostResult<T>(string url, object? payload = null)
        {
            var output = RestHelper.ExecutePostRequest(Context, url, payload);
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
            var output = RestHelper.ExecutePostMultiformData(Context, Url, fileName, data);
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
            var output = RestHelper.ExecuteDeleteRequest(Context, url, payload);
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
                if (this.Context != null)
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

        internal bool ParameterSpecified(string parameterName)
        {
            return MyInvocation.BoundParameters.ContainsKey(parameterName);
        }

    }
}