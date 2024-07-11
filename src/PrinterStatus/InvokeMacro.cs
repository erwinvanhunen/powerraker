using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsLifecycle.Invoke, PREFIX + "Macro")]
    public class InvokeMacro : KlipperCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = false)]
        public string? Parameters { get; set; }

        public object GetDynamicParameters()
        {

            var parameterDictionary = new RuntimeDefinedParameterDictionary();
            GetMacros(parameterDictionary);

            return parameterDictionary;
        }

        private void GetMacros(RuntimeDefinedParameterDictionary parameterDictionary)
        {
            const string parameterName = "Name";
            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = true,
            };

            attributeCollection.Add(parameterAttribute);

            var objects = GetResult<ObjectsList>("/printer/objects/list");

            if (objects != null)
            {
                var fans = objects.Objects.Where(o => o.StartsWith("gcode_macro"));
                var attributes = fans.Select(f => f.Split(" ")[1]);
                var validateSetAttribute = new ValidateSetAttribute(attributes.ToArray());
                attributeCollection.Add(validateSetAttribute);

                var runtimeParameter = new RuntimeDefinedParameter(parameterName, typeof(string), attributeCollection);

                parameterDictionary.Add(parameterName, runtimeParameter);
            }
        }

        private string? Macro
        {
            get
            {
                if (ParameterSpecified("Name") && MyInvocation.BoundParameters["Name"] != null)
                {
                    return MyInvocation.BoundParameters["Name"] as string;
                }
                else
                {
                    return null;
                }
            }
        }
        protected override void ExecuteCmdlet()
        {

            if (Macro != null)
            {
                var gcode = Macro;
                if (ParameterSpecified(nameof(Parameters)))
                {
                    gcode += $" {Parameters}";
                }
                SendGCode(gcode);
            }
        }
    }
}

