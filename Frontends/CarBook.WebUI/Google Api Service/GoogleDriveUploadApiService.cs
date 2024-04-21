using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace CarBook.WebUI.Google_Api_Service
{
    public class GoogleDriveUploadApiService
    {
        string _credentialsPath;
        string _folderid;
        string[] _filesToUPload;

        public GoogleDriveUploadApiService(string credentialsPath,string folderid, string[] filesToUPload)
        {
            _credentialsPath = credentialsPath;
            _folderid = credentialsPath;
            _filesToUPload = filesToUPload;
        }

        public void UploadsFilesToGoogleDrive()
        {
            GoogleCredential credential;
            using (var stream = new FileStream(_credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
                {
                    DriveService.ScopeConstants.DriveFile
                });

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive Upload Console App"
                });

                foreach (var filePath in _filesToUPload)
                {
                    var fileMetaData = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = Path.GetFileName(filePath),
                        Parents = new List<string> { _folderid }
                    };

                    FilesResource.CreateMediaUpload request;
                    using (var streamm = new FileStream(filePath, FileMode.Open))
                    {
                        request = service.Files.Create(fileMetaData, streamm, "");
                        request.Fields = "id";
                        request.Upload();
                    }

                    var uploadFile = request.ResponseBody;
                    //Console.WriteLine($"File '{fileMetaData.Name}' uploaded with ID: {uploadFile.Id}");
                }
            }
        }
    }
}
