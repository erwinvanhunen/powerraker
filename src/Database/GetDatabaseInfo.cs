using System.Management.Automation;
using PowerRaker.Model.Database;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Get, "DatabaseInfo")]
    public class GetDatabaseInfo : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var databaseInfo = GetResult<DatabaseInfo>("/server/database/list");
            WriteObject(databaseInfo, true);

        }
    }

}