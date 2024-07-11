using System.Management.Automation;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "PrinterObject")]
    public class GetPrinterObject : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public string? Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Name)))
            {
                var o = GetResult<ObjectStatus<object>>($"/printer/objects/query?{Name}");
                if (o.Status.TryGetValue(Name, out object? value))
                {
                    WriteObject(Utils.JsonToPSObjectConverter.ConvertToPSObject(JsonSerializer.Serialize(value)));
                }
            }
            else
            {
                var objects = GetResult<ObjectsList>("/printer/objects/list");
                if (objects != null)
                {
                    WriteObject(objects.Objects, true);
                }
            }

        }
    }

}