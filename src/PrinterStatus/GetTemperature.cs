using System;
using System.Globalization;
using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{


    [Cmdlet(VerbsCommon.Get, PREFIX + "Temperature")]
    public class GetTemperature : KlipperCmdlet, IDynamicParameters
    {
        private Dictionary<string, string> sensors = new Dictionary<string, string>();

        public object GetDynamicParameters()
        {
            var parameterDictionary = new RuntimeDefinedParameterDictionary();
            GetSensors(parameterDictionary);
            return parameterDictionary;
        }

        private void GetSensors(RuntimeDefinedParameterDictionary parameterDictionary)
        {
            const string parameterName = "Sensor";
            var objects = GetResult<ObjectsList>("/printer/objects/list");

            var attributeCollection = new System.Collections.ObjectModel.Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute
            {
                ValueFromPipeline = false,
                ValueFromPipelineByPropertyName = false,
                Mandatory = false,
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

        private List<string> Getall()
        {
            var objects = GetResult<ObjectsList>("/printer/objects/list");
            var returnValue = new List<string>();
            returnValue.AddRange(objects.Objects.Where(o => o.StartsWith("temperature")));
            returnValue.Add("extruder");
            returnValue.Add("heater_bed");
            return returnValue;
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
            }
            else
            {

                var txtInfo = Host.CurrentCulture.TextInfo;
                var allObjects = Getall();
                var objectString = string.Join('&', allObjects);

                var o = GetResult<ObjectStatus<TemperatureSensor>>($"/printer/objects/query?{objectString}");
                foreach (var sensor in allObjects)
                {
                    o.Status.TryGetValue(sensor, out TemperatureSensor? value);
                    var name = sensor.IndexOf(" ") > 0 ? sensor.Split(" ")[1] : sensor;
                    var outputObject = new
                    {
                        Name = name,
                        FriendlyName = txtInfo.ToTitleCase(name.Replace("_", " ")),
                        value.Temperature
                    };
                    WriteObject(outputObject);
                }
            }
        }
    }
}