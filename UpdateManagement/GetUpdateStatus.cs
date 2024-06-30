using System.Management.Automation;
using powerraker.announcements;


namespace powerraker.updatemanagement
{

    [Cmdlet(VerbsCommon.Get, "UpdateStatus")]
    public class GetUpdateStatus : RakerCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Refresh { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter ShowAll { get; set; }
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<UpdateStatus>($"/machine/update/status?refresh={(Refresh ? "true" : "false")}");
            if (ShowAll)
            {
                WriteObject(result, true);
            }
            else
            {
                var updates = result.VersionInfo.Where(u => u.Value.Version != u.Value.RemoteVersion);
                WriteObject(updates, true);
            }
        }
    }
}