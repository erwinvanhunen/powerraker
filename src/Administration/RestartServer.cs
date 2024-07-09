using System.Management.Automation;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsLifecycle.Restart, "Server")]

    public class RestartServer : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/server/restart");
            WriteObject(result);
        }
    }
}