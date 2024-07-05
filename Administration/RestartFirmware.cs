using System.Management.Automation;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsLifecycle.Restart, "Firmware")]

    public class RestartFirmware: RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/printer/firmware_restart");
            WriteObject(result);
        }
    }
}