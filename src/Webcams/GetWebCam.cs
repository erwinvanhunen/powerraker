using System.Management.Automation;
using PowerRaker.Model.Webcams;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "Webcam")]
    public class GetWebcam : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var webcams = GetResult<WebcamList>("/server/webcams/list");
            if (webcams != null)
            {
                WriteObject(webcams.Webcams, true);
            }
        }
    }

}