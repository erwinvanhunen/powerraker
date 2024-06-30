using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using powerraker.announcements;
using powerraker.model.printerstatus;

namespace powerraker.printmanagement
{

    [Cmdlet(VerbsCommon.Get, "Announcement")]
    public class GetAnnouncement : RakerCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeDismissed {get;set;}
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<List<Announcement>>($"/server/announcements/list?include_dismissed={(IncludeDismissed ? "false" : "true")}","entries");
            WriteObject(result,true);
        }
    }
}