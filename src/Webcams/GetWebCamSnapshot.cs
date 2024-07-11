using System.Management.Automation;
using PowerRaker.Model.Webcams;

namespace PowerRaker.Webcams
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "WebcamShapshot")]
    public class GetWebcamSnapshot : KlipperCmdlet
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
                    var snapshotData = GetBinaryResult(selectedWebcam.SnapshotUrl);

                    File.WriteAllBytes(Filename, snapshotData);
                    WriteObject(new { Filename = Filename, Size = snapshotData.Length });
                }
                else
                {
                    throw new ItemNotFoundException("Webcam not found");
                }
            }
        }
    }

}