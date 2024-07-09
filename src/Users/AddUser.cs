using System.Management.Automation;
using PowerRaker.Model.Users;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Add, "User")]
    public class AddUser : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Username { get; set; }

        [Parameter(Mandatory = true)]
        public required string Password { get; set; }

        protected override void ExecuteCmdlet()
        {
            var user = PostResult<AuthInfo>("/access/user", new { username = Username, password = Password });
            if (user != null)
            {
                WriteObject(user);
            }
        }
    }

}