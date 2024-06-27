using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "WebCam")]
    public class GetWebCam : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var output = RestHelper.ExecuteGetRequest(this.Connection, "/server/webcams/list");
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output);
            var jobs = jsonDocument.RootElement.GetProperty("result").GetProperty("webcams");
            WriteObject(jobs.Deserialize<List<Webcam>>());
        }
    }

}