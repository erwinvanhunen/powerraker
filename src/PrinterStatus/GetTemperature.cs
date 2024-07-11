using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{


    [Cmdlet(VerbsCommon.Get, PREFIX + "Temperature")]
    public class GetTemperature : KlipperCmdlet, IDynamicParameters
    {
        private Dictionary<string, string> sensors = new Dictionary<string, string>();
        private const string ParameterSet_HEATERS = "Sensor";
        private const string ParameterSet_FANS = "Fans";

        public object GetDynamicParameters()
        {

            var parameterDictionary = new RuntimeDefinedParameterDictionary();
            var objects = GetResult<ObjectsList>("/printer/objects/list");
            if (objects != null)
            {
                GetSensors(objects, parameterDictionary);
            }
            return parameterDictionary;
        }

        private void GetSensors(ObjectsList objects, RuntimeDefinedParameterDictionary parameterDictionary)
        {
            const string parameterName = "Sensor";
            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = false,
                ParameterSetName = ParameterSet_FANS
            };

            attributeCollection.Add(parameterAttribute);


            objects.Objects.Where(o => o.StartsWith("temperature")).ToList().ForEach(a => sensors.Add(a.Split(" ")[1], a));
            sensors.Add("extruder", "extruder");
            sensors.Add("heater_bed", "heater_bed");

            var validateSetAttribute = new ValidateSetAttribute(sensors.Keys.ToArray());
            attributeCollection.Add(validateSetAttribute);

            var runtimeParameter = new RuntimeDefinedParameter(parameterName, typeof(string), attributeCollection);

            parameterDictionary.Add(parameterName, runtimeParameter);
        }


        private string? Sensor
        {
            get
            {
                if (ParameterSpecified(nameof(Sensor)) && MyInvocation.BoundParameters[nameof(Sensor)] != null)
                {
                    return MyInvocation.BoundParameters[nameof(Sensor)] as string;
                }
                else
                {
                    return null;
                }
            }
        }


        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Sensor)))
            {
                if (sensors.TryGetValue(Sensor, out string? fullSensorQualifier))
                {
                    var o = GetResult<ObjectStatus<TemperatureSensor>>($"/printer/objects/query?{fullSensorQualifier}");
                    if (o.Status.TryGetValue(fullSensorQualifier, out TemperatureSensor? value))
                    {
                        WriteObject(value.Temperature);
                    }
                }
                // if (ParameterSetName == ParameterSet_HEATERS)
                // {
                //     SendGCode($"SET_HEATER_TEMPERATURE HEATER={Heater} TARGET={TargetTemperature}");
                // }
                // else
                // {
                //     SendGCode($"SET_TEMPERATURE_FAN_TARGET TEMPERATURE_FAN={Fan} TARGET={TargetTemperature}");
                // }

            }
        }
    }
}