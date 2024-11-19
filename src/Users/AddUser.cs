using System.Management.Automation;
using System.Net;
using System.Security;
using PowerRaker.Model.Users;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Add, PREFIX + "User")]
    public class AddUser : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Username { get; set; }

        [Parameter(Mandatory = true)]
        public required SecureString Password { get; set; }

        protected override void ExecuteCmdlet()
        {
        
            var user = PostResult<AuthInfo>("/access/user", new { username = Username, password = new NetworkCredential("",Password).Password });
            if (user != null)
            {
                WriteObject(user);
            }
        }
    }

}