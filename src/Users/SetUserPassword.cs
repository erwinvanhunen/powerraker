using System.Management.Automation;
using PowerRaker.Model.Users;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Set, "UserPassword")]
    public class UserPassword : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string CurrentPassword { get; set; }

        [Parameter(Mandatory = true)]
        public required string NewPassword { get; set; }

        protected override void ExecuteCmdlet()
        {
            var authInfo = PostResult<AuthInfo>("/access/user/password", new { password = CurrentPassword, new_password = NewPassword });
            if (authInfo != null)
            {
                WriteObject(authInfo);
            }
        }
    }

}