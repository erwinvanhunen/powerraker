using System.Management.Automation;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "PrinterObject")]
    public class GetPrinterObject : KlipperCmdlet, IDynamicParameters
    {
        // [Parameter(Mandatory = false)]
        // public string? Name { get; set; }


        public object GetDynamicParameters()
        {
            var parameterDictionary = new RuntimeDefinedParameterDictionary();
            GetObjects(parameterDictionary);
            return parameterDictionary;
        }

        private void GetObjects(RuntimeDefinedParameterDictionary parameterDictionary)
        {
            var objects = GetResult<ObjectsList>("/printer/objects/list");

            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = false,
            };

            attributeCollection.Add(parameterAttribute);

            var validateSetAttribute = new ValidateSetAttribute(objects.Objects.ToArray());
            attributeCollection.Add(validateSetAttribute);

            var runtimeParameter = new RuntimeDefinedParameter(nameof(Name), typeof(string), attributeCollection);

            parameterDictionary.Add(nameof(Name), runtimeParameter);
        }

        private string? Name
        {
            get
            {
                if (ParameterSpecified(nameof(Name)) && MyInvocation.BoundParameters[nameof(Name)] != null)
                {
                    return MyInvocation.BoundParameters[nameof(Name)] as string;
                }
                else
                {
                    return null;
                }
            }
        }

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