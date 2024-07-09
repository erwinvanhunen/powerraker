using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{
    public enum LogRollOverApplication
    {
        Moonraker,
        Klipper
    }

    [Cmdlet(VerbsLifecycle.Request, "LogRollover")]
    public class RequestLogRollover : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public required LogRollOverApplication Application { get; set; } = LogRollOverApplication.Moonraker;

        protected override void ExecuteCmdlet()
        {
            var result = PostResult<LogRolloverResult>("/server/logs/rollover", new { application = Application.ToString().ToLowerInvariant() });
            WriteObject(result);
        }
    }
}