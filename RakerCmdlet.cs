using System.Management;
using System.Management.Automation;
using System.Net;

namespace powerraker
{
    public abstract class RakerCmdlet : PSCmdlet
    {
        public RakerConnection Connection
        {
            get { return RakerConnection.Current; }
        }
        protected virtual void ExecuteCmdlet()
        { }

        protected override void ProcessRecord()
        {
            try
            {
                ExecuteCmdlet();
            }
            catch (Exception ex)
            {
                throw new PSInvalidOperationException(ex.Message);
            }
        }

    }
}