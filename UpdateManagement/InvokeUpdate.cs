using System.Management.Automation;

namespace PowerRaker.UpdateManagement
{

    [Cmdlet(VerbsLifecycle.Invoke, "Update")]
    public class InvokeUpdate : RakerCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = "System")]
        public SwitchParameter SystemUpdate { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Clients")]
        public required string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            if (SystemUpdate)
            {
                WriteWarning("Notice that due to the time a system update can take, the remote request will very likely timeout. This is not an error. Check the Fluidd or Mainsail UI for status.");
                var systemResult = PostResult<string>("/machine/update/system");
                WriteObject(systemResult);
            }
            var result = PostResult<string>($"/machine/update/client?name={Name}");
            WriteObject(result);
        }
    }
}