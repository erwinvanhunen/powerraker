using System.Management.Automation;

namespace powerraker.administration
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