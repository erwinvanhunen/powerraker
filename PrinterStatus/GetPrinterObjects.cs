using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, "PrinterObjects")]
    public class GetPrinterObjects : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var objects = GetResult<ObjectsList>("/printer/objects/list");
            if (objects != null)
            {
                WriteObject(objects.Objects, true);
            }

        }
    }

}