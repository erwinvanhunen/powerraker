using System.Management.Automation;
using System.Security;

namespace PowerRaker;

[Cmdlet(VerbsCommunications.Connect, "Printer")]
public class ConnectPrinter : PSCmdlet
{
    [Parameter(Mandatory = true, Position = 0, ParameterSetName = ParameterAttribute.AllParameterSets)]
    public required string Printer { get; set; }

    [Parameter(Mandatory = false, ParameterSetName = "APIKey")]
    public string? APIKey { get; set; } = null;


    [Parameter(Mandatory = true, ParameterSetName = "User")]
    public string? Username { get; set; }

    [Parameter(Mandatory = true, ParameterSetName = "User")]
    public SecureString? Password { get; set; }

    [Parameter(Mandatory = false, ParameterSetName = "User")]
    public string? Source { get; set; } = "moonraker";

    protected override void ProcessRecord()
    {
        RakerConnection connection = null;
        switch (ParameterSetName)
        {
            case "APIKey":
                {
                    connection = new RakerConnection(Printer, APIKey ?? null);
                    break;
                }
            case "User":
                {
                    connection = new RakerConnection(Printer, Username, Password, Source);
                    break;
                }

        }
        RakerConnection.Current = connection;
    }
}
