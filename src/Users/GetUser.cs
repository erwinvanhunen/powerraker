using System.Management.Automation;
using PowerRaker.Model.Users;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "User")]
    public class GetUser : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Current { get; set; }

        protected override void ExecuteCmdlet()
        {
            if (Current)
            {
                var user = GetResult<User>("/access/user");
                if (user != null)
                {
                    WriteObject(user);
                }
            }
            else
            {
                var list = GetResult<UserList>("/access/users/list");
                if (list != null && list.Users != null)
                {
                    WriteObject(list.Users, true);
                }
            }
        }
    }

}