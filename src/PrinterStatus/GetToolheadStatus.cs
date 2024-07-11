using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "ToolheadStatus")]
    public class GetToolheadStatus : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Extended { get; set; }

        protected override void ExecuteCmdlet()
        {
            var result = GetResult<ObjectStatus<Toolhead?>>($"/printer/objects/query?toolhead");
            result.Status.TryGetValue("toolhead", out Toolhead? toolhead);
            if (Extended)
            {
                WriteObject(toolhead);
            }
            else
            {
                var returnObject = new PSObject();
                returnObject.Properties.Add(new PSNoteProperty("X", toolhead.Position[0]));
                returnObject.Properties.Add(new PSNoteProperty("Y", toolhead.Position[1]));
                returnObject.Properties.Add(new PSNoteProperty("Z", toolhead.Position[2]));
                WriteObject(returnObject);
            }
        }
    }
}
