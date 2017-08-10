using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using ImagesViewer.Models.Repositories;
using Newtonsoft.Json.Linq;

namespace ImagesViewer.Models.Services
{
    public class ImageService
    {
        private readonly IImagesRepository repository;
        private readonly RecognitionService recognitionService;

        public ImageService(IImagesRepository repository, RecognitionService recognitionService)
        {
            this.repository = repository;
            this.recognitionService = recognitionService;
        }

        public IEnumerable<ImageInfo> GetAllImages()
        {
            return repository.GetAll();
        }

        public void AddImages(IEnumerable<HttpContent> files)
        {
            foreach (var img in files)
            {
                var recognizedImage = recognitionService.GetLabels(img);
                repository.Add(new ImageInfo()
                {
                    Title = recognizedImage.Item2,
                    Description = recognizedImage.Item3,
                    ImageBytes = recognizedImage.Item1
                });
            }
        }

        public void DeleteImage(int id)
        {
            repository.Remove(id);
        }
    }
}