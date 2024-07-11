using System.Management.Automation;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsLifecycle.Restart, PREFIX + "Firmware")]

    public class RestartFirmware : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/printer/firmware_restart");
            WriteObject(result);
        }
    }
}