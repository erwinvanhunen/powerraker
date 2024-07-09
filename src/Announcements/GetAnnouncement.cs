using System.Management.Automation;
using PowerRaker.Model.Announcements;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsCommon.Get, "Announcement")]
    public class GetAnnouncement : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeDismissed { get; set; }
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<Announcements>($"/server/announcements/list?include_dismissed={(IncludeDismissed ? "false" : "true")}");
            if (result != null)
            {
                WriteObject(result?.Entries, true);
            }
        }
    }
}