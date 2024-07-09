using System.Management.Automation;
using PowerRaker.Model.Users;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Remove, "User")]
    public class RemoveUser : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Username { get; set; }
        protected override void ExecuteCmdlet()
        {
            var user = DeleteResult<AuthInfo>("/access/user", new { username = Username });
            if (user != null)
            {
                WriteObject(user);
            }
        }
    }

}