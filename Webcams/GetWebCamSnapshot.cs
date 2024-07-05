using System.Management.Automation;
using PowerRaker.Model.Webcams;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Get, "WebCamShapshot")]
    public class GetWebCamSnapshot : RakerCmdlet
    {
        [Parameter(Mandatory = false)]
        public string? Webcam = null;

        [Parameter(Mandatory = false)]
        public string? Filename = null;

        protected override void ExecuteCmdlet()
        {
            var webcams = GetResult<List<Webcam>>("/server/webcams/list");
            if (webcams != null)
            {
                Webcam? selectedWebcam = null;
                if (Webcam == null)
                {
                    selectedWebcam = webcams.First();
                }
                else
                {
                    selectedWebcam = webcams.FirstOrDefault(w => w.Name == Webcam);
                }
                if (selectedWebcam != null)
                {
                    if (Filename == null)
                    {
                        Filename = $"snapshot-{DateTime.Now:yyyyMMdd-HHmmss}.jpg";
                    }
                    if (!System.IO.Path.IsPathRooted(Filename))
                    {
                        Filename = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Filename);
                    }
#pragma warning disable CS8604 // Possible null reference argument.
                    var snapshotData = RestHelper.ExecuteGetRequestBinary(this.Connection, selectedWebcam.SnapshotUrl);
#pragma warning restore CS8604 // Possible null reference argument.
                    File.WriteAllBytes(Filename, snapshotData);
                    WriteObject(new { Filename = Filename, Size = snapshotData.Length });
                }
                else
                {
                    throw new ItemNotFoundException("Webcam not found");
                    //WriteError(new ErrorRecord(new ItemNotFoundException($"Webcam {Webcam} not found. Use Get-PrinterWebCam to retrieve webcam."), "WEBCAMNOTFOUND", ErrorCategory.InvalidArgument, this));
                }
            }
        }
    }

}