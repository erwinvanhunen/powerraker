using System.Management.Automation;
using System.Security;

namespace PowerRaker;

[Cmdlet(VerbsCommunications.Connect, PREFIX + "Printer")]
public class ConnectPrinter : CmdletBase
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

    [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
    public SwitchParameter ReturnConnection { get; set; }

    protected override void ProcessRecord()
    {
        PrinterContext? connection = null;
        switch (ParameterSetName)
        {
            case "APIKey":
                {
                    connection = new PrinterContext(Printer, APIKey ?? null);
                    break;
                }
            case "User":
                {
                    connection = new PrinterContext(Printer, Username, Password, Source);
                    break;
                }

        }
        PrinterContext.Current = connection;
        if (ReturnConnection)
        {
            WriteObject(connection);
        }
    }
}
