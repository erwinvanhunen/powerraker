using System.Management.Automation;

namespace PowerRaker
{
    public class CmdletBase : PSCmdlet
    {
        internal const string PREFIX = "Klipper";

        internal bool ParameterSpecified(string parameterName)
        {
            return MyInvocation.BoundParameters.ContainsKey(parameterName);
        }

    }
}