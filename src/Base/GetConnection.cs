using System.Management.Automation;

namespace PowerRaker
{
    [Cmdlet(VerbsCommon.Get, PREFIX + "Connection")]
    public class GetConnection : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            WriteObject(PrinterContext.Current);
        }
    }
}