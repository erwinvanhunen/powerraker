using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker.webcams
{

    [Cmdlet(VerbsDiagnostic.Test, "WebCam")]
    public class TestWebCam : RakerCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "ByName")]
        public required string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            var webcams = GetResult<List<Webcam>>("/server/webcams/list", "webcams");
            if (webcams != null)
            {
                var webcam = webcams.FirstOrDefault(w => w.Name == Name);
                if (webcam != null)
                {
                    var testResult = PostResult<WebcamTest>($"/server/webcams/test?uid={webcam.Uid}", null);
                    WriteObject(testResult, true);
                }

            }
        }

    }
}