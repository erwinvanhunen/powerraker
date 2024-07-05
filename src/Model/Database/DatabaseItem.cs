using System.Management.Automation;
using System.Text.Json.Serialization;
using PowerRaker.Utils;

namespace PowerRaker.Model.Database
{
    public class DatabaseItem
    {
        public string? Namespace { get; set; }
        public string? Key { get; set; }

        [JsonPropertyName("value")]
        public object? RawValue { get; set; }

        [JsonIgnore]
        public PSObject? Value
        {
            get
            {
                if (RawValue != null && !string.IsNullOrEmpty(RawValue.ToString()))
                {
                    var stringValue = RawValue.ToString();
                    if (stringValue != null)
                    {
                        return JsonToPSObjectConverter.ConvertToPSObject(stringValue);
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }


}
