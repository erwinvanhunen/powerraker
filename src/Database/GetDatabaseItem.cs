using System.Management.Automation;
using PowerRaker.Model.Database;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Get, "DatabaseItem")]
    public class GetDatabaseItem : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Namespace {get;set;}
        
        [Parameter(Mandatory = false)]
        public string? Key {get;set;}

        protected override void ExecuteCmdlet()
        {
            var url = $"/server/database/item?namespace={Namespace}";
            if(!string.IsNullOrEmpty(Key))
            {
                url += $"&key={Key}";
            }
            var databaseItem = GetResult<DatabaseItem>(url);
            WriteObject(databaseItem, true);

        }
    }

}