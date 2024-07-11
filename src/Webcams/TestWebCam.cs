using System.Management.Automation;
using PowerRaker.Model.Webcams;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsDiagnostic.Test, PREFIX +  "Webcam")]
    public class TestWebcam : KlipperCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "ByName")]
        public required string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            var webcams = GetResult<WebcamList>("/server/webcams/list");
            if (webcams != null && webcams.Webcams != null)
            {
                var webcam = webcams.Webcams.FirstOrDefault(w => w.Name == Name);
                if (webcam != null)
                {
                    var testResult = PostResult<WebcamTest>($"/server/webcams/test?uid={webcam.Uid}", null);
                    WriteObject(testResult, true);
                }

            }
        }

    }
}