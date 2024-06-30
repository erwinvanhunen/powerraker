using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker.webcams
{

    [Cmdlet(VerbsCommon.Get, "WebCam")]
    public class GetWebCam : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var webcams = GetResult<List<Webcam>>("/server/webcams/list","webcams");
            WriteObject(webcams,true);
           
        }
    }

}