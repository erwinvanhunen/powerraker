using System.Management.Automation;

namespace PowerRaker.UpdateManagement
{

    [Cmdlet(VerbsLifecycle.Invoke, PREFIX + "Update")]
    public class InvokeUpdate : KlipperCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = "System")]
        public SwitchParameter SystemUpdate { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Clients")]
        public required string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteCmdlet()
        {

            if (SystemUpdate)
            {
                WriteWarning("Notice that due to the time a system update can take, the remote request will very likely timeout. This is not an error. Check the Fluidd or Mainsail UI for status.");
                if (Force || ShouldContinue($"Invoke system update?", "Update"))
                {
                    var systemResult = PostResult<string>("/machine/update/system");
                    WriteObject(systemResult);
                }
            }
            else
            {
                if (Force || ShouldContinue($"Invoke update for {Name}?", "Update"))
                {
                    var result = PostResult<string>($"/machine/update/client?name={Name}");
                    WriteObject(result);
                }
            }
        }
    }
}