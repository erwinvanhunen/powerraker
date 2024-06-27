using System.Management.Automation;

namespace powerraker;

[Cmdlet(VerbsCommunications.Connect, "Printer")]
public class ConnectPrinter : Cmdlet
{
    [Parameter(Mandatory = true)]
    public required string Printer { get; set; }

    protected override void ProcessRecord()
    {
        var connection = new RakerConnection(Printer);
        RakerConnection.Current = connection;
    }
}
