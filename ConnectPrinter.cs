using System.Management.Automation;

namespace powerraker;

[Cmdlet(VerbsCommunications.Connect, "Printer")]
public class ConnectPrinter : Cmdlet
{
    [Parameter(Mandatory = true)]
    public required string Printer { get; set; }

    [Parameter(Mandatory = false)
    public string? APIKey {get;set;}]

    protected override void ProcessRecord()
    {
        var connection = new RakerConnection(Printer, APIKey);
        RakerConnection.Current = connection;
    }
}
