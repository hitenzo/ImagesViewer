using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;

namespace ImagesViewer.Models.Services
{
    public class RecognitionService
    {
        // path to the json file which you need to generate
        private string apiKeyPath = "";

        //name of your app in gogle console
        private string appName = "";



        public GoogleCredential CreateCredentials(string path)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var c = GoogleCredential.FromStream(stream);
                credential = c.CreateScoped(VisionService.Scope.CloudPlatform);
            }

            return credential;
        }

        public VisionService CreateService(string applicationName, IConfigurableHttpClientInitializer credentials)
        {
            var service = new VisionService(new BaseClientService.Initializer()
            {
                ApplicationName = applicationName,
                HttpClientInitializer = credentials
            });

            return service;
        }

        public AnnotateImageRequest CreateAnnotationImageRequest(HttpContent content, string[] featureTypes)
        {
            //if (!File.Exists(path))
            //{
            //    throw new FileNotFoundException("Not found.", path);
            //}

            var request = new AnnotateImageRequest();
            request.Image = new Image();

            var bytes = content.ReadAsByteArrayAsync().Result;
            request.Image.Content = Convert.ToBase64String(bytes);

            request.Features = new List<Feature>();

            foreach (var featureType in featureTypes)
            {
                request.Features.Add(new Feature() { Type = featureType });
            }

            return request;
        }

        public AnnotateImageResponse Annotate(VisionService service, HttpContent content, string[] features)
        {
            var request = new BatchAnnotateImagesRequest();
            request.Requests = new List<AnnotateImageRequest>();
            request.Requests.Add(CreateAnnotationImageRequest(content, features));

            var result = service.Images.Annotate(request).Execute();

            if (result?.Responses?.Count > 0)
            {
                return result.Responses[0];
            }

            return null;
        }

        //TODO: change method to recive list of httpContent 
        public string GetLabels(HttpContent content)
        {
            var credentails = CreateCredentials(apiKeyPath);
            var service = CreateService(appName, credentails);

            var name = content.Headers.ContentDisposition.FileName;
            name = name.Remove(name.Length - 1, 1).Remove(0, 1);

            var task = Annotate(service, content, new string[] { "LABEL_DETECTION" });
            var tags = task?.LabelAnnotations?.Select(s => s.Description).ToArray();
            var labels = String.Join(", ", tags);
            labels = name + ": " + labels;
            return labels;
        }
    }
}