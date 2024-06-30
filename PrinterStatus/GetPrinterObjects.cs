using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker.printerstatus
{

    [Cmdlet(VerbsCommon.Get, "PrinterObjects")]
    public class GetPrinterObjects : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var objects = GetResult<List<string>>("/printer/objects/list","objects");
            WriteObject(objects,true);
           
        }
    }

}