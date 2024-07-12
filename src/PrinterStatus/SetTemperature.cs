using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{


    [Cmdlet(VerbsCommon.Set, PREFIX + "Temperature")]
    public class SetTemperature : KlipperCmdlet, IDynamicParameters
    {

        private const string ParameterSet_HEATERS = "Heaters";
        private const string ParameterSet_FANS = "Fans";

        [Parameter(Mandatory = true)]
        public double TargetTemperature { get; set; }

        public object GetDynamicParameters()
        {

            var parameterDictionary = new RuntimeDefinedParameterDictionary();
            GetHeater(parameterDictionary);
            GetFans(parameterDictionary);
            return parameterDictionary;
        }

        private void GetHeater(RuntimeDefinedParameterDictionary parameterDictionary)
        {
            const string parameterName = "Heater";
            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = false,
                ParameterSetName = ParameterSet_HEATERS
            };

            attributeCollection.Add(parameterAttribute);

            var statusResult = GetResult<ObjectStatus<Heaters?>>("/printer/objects/query?heaters");
            statusResult.Status.TryGetValue("heaters", out Heaters? heaters);

            if (heaters != null)
            {
                if (heaters.AvailableHeaters.Any())
                {
                    var attributes = heaters.AvailableHeaters;

                    var validateSetAttribute = new ValidateSetAttribute(attributes.ToArray());
                    attributeCollection.Add(validateSetAttribute);

                    var runtimeParameter = new RuntimeDefinedParameter(parameterName, typeof(string), attributeCollection);

                    parameterDictionary.Add(parameterName, runtimeParameter);
                }
            }
        }

        private void GetFans(RuntimeDefinedParameterDictionary parameterDictionary)
        {
            const string parameterName = "Fan";
            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = false,
                ParameterSetName = ParameterSet_FANS
            };

            attributeCollection.Add(parameterAttribute);

            var objects = GetResult<ObjectsList>("/printer/objects/list");

            if (objects != null)
            {
                var fans = objects.Objects.Where(o => o.StartsWith("temperature_fan"));
                if (fans.Any())
                {
                    var attributes = fans.Select(f => f.Split(" ")[1]);
                    var validateSetAttribute = new ValidateSetAttribute(attributes.ToArray());
                    attributeCollection.Add(validateSetAttribute);

                    var runtimeParameter = new RuntimeDefinedParameter(parameterName, typeof(string), attributeCollection);
                    parameterDictionary.Add(parameterName, runtimeParameter);
                }

            }
        }

        private string? Heater
        {
            get
            {
                if (ParameterSpecified(nameof(Heater)) && MyInvocation.BoundParameters[nameof(Heater)] != null)
                {
                    return MyInvocation.BoundParameters[nameof(Heater)] as string;
                }
                else
                {
                    return null;
                }
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
            if (ParameterSetName == ParameterSet_HEATERS)
            {
                SendGCode($"SET_HEATER_TEMPERATURE HEATER={Heater} TARGET={TargetTemperature}");
            }
            else
            {
                SendGCode($"SET_TEMPERATURE_FAN_TARGET TEMPERATURE_FAN={Fan} TARGET={TargetTemperature}");
            }

        }
    }
}