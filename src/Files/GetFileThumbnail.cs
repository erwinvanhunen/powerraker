using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using PowerRaker.Model.Files;
using PowerRaker.Utils;

namespace PowerRaker.Files
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "FileThumbnail")]
    public class GetFileThumbnail : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Filename { get; set; }

        protected override void ExecuteCmdlet()
        {
            var thumbnails = GetResult<List<Thumbnail>>($"/server/files/thumbnails?filename={Filename}");

            if (thumbnails != null && thumbnails.Count > 0)
            {
                var overwriteall = false;
                var overwritenone = true;
                foreach (var thumbnail in thumbnails)
                {
                    if (thumbnail.ThumbnailPath != null)
                    {
                        var bytes = RestHelper.ExecuteGetRequestBinary(this.Context, "/server/files/gcodes/" + thumbnail.ThumbnailPath);
                        var thumbnailFilename = new FileInfo(thumbnail.ThumbnailPath).Name;
                        var filePath = "";
                        if (!Path.IsPathRooted(thumbnailFilename))
                        {
                            filePath = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, thumbnailFilename);
                        }
                        if (System.IO.File.Exists(filePath))
                        {
                            if (!overwriteall)
                            {
                                var choices = new Collection<ChoiceDescription> { new ChoiceDescription("&Yes"), new ChoiceDescription("&No"), new ChoiceDescription("&All"), new ChoiceDescription("N&one") };
                                var choice = Host.UI.PromptForChoice("File exists", $"{thumbnailFilename} exists. Overwrite?", choices, 0);
                                if (choice == 2)
                                {
                                    overwriteall = true;
                                }
                                if (choice == 3)
                                {
                                    overwritenone = true;
                                }
                                if (choice == 0 || overwriteall)
                                {
                                    System.IO.File.WriteAllBytes(filePath, bytes);
                                    WriteObject(thumbnailFilename);
                                }
                            }
                            else
                            {
                                if (!overwritenone)
                                {
                                    System.IO.File.WriteAllBytes(filePath, bytes);
                                    WriteObject(thumbnailFilename);
                                }
                            }
                        }
                        else
                        {
                            if (!overwritenone)
                            {
                                System.IO.File.WriteAllBytes(filePath, bytes);
                                WriteObject(thumbnailFilename);
                            }
                        }
                    }
                }
            }
        }
    }
}