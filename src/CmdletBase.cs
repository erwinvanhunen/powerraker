using System.Management.Automation;

public class CmdletBase : PSCmdlet
{
    internal const string PREFIX = "Klipper";

    internal bool ParameterSpecified(string parameterName)
    {
        return MyInvocation.BoundParameters.ContainsKey(parameterName);
    }

}