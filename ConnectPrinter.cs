using System.Management.Automation;

namespace PowerRaker;

[Cmdlet(VerbsCommunications.Connect, "Printer")]
public class ConnectPrinter : Cmdlet
{
    [Parameter(Mandatory = true, Position = 0)]
    public required string Printer { get; set; }

    [Parameter(Mandatory = false)]
    public string? APIKey {get;set;} = null;

    protected override void ProcessRecord()
    {
        var connection = new RakerConnection(Printer, APIKey ?? null);
        RakerConnection.Current = connection;
    }
}
