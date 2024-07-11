using System.Globalization;
using System.Management.Automation;
using System.Threading.Tasks.Dataflow;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Set, PREFIX + "Fan")]
    public class SetFan : KlipperCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(0, 100)]
        public int Percentage { get; set; }

        public object GetDynamicParameters()
        {

            var parameterDictionary = new RuntimeDefinedParameterDictionary();
            GetFans(parameterDictionary);
            return parameterDictionary;
        }

        private void GetFans(RuntimeDefinedParameterDictionary parameterDictionary)
        {
            const string parameterName = "Fan";
            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = true
            };

            attributeCollection.Add(parameterAttribute);

            var objects = GetResult<ObjectsList>("/printer/objects/list");

            if (objects != null)
            {
                var fans = objects.Objects.Where(o => o.StartsWith("output_pin fan"));
                var attributes = fans.Select(f => f.Split(" ")[1]);
                var validateSetAttribute = new ValidateSetAttribute(attributes.ToArray());
                attributeCollection.Add(validateSetAttribute);

                var runtimeParameter = new RuntimeDefinedParameter(parameterName, typeof(string), attributeCollection);

                parameterDictionary.Add(parameterName, runtimeParameter);
            }
        }

        private string? Fan
        {
            get
            {
                if (ParameterSpecified(nameof(Fan)) && MyInvocation.BoundParameters[nameof(Fan)] != null)
                {
                    return MyInvocation.BoundParameters[nameof(Fan)] as string;
                }
                else
                {
                    return null;
                }
            }
        }


        protected override void ExecuteCmdlet()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            var values = new List<string>();
            double value = (Percentage / 100.0) * 255.0;
            SendGCode($"SET_PIN PIN={Fan} VALUE={value.ToString(nfi)}");
            //}

        }
    }
}

