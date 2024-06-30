using System.Management.Automation;

namespace powerraker.administration
{
    [Cmdlet(VerbsLifecycle.Restart, "Server")]

    public class RestartServer : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/server/restart");
            WriteObject(result);
        }
    }
}