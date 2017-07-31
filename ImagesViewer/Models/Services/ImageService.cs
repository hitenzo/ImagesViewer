using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImagesViewer.Models.Repositories;

namespace ImagesViewer.Models.Services
{
    public class ImageService
    {
        private readonly IImagesRepository repository;

        public ImageService(IImagesRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ImageInfo> GetAllImages()
        {
            return repository.GetAll();
        }

        public void AddImages(List<string> imagesInfo)
        {
            foreach (var img in imagesInfo)
            {
                var separator = img.IndexOf(":");
                var name = img.Substring(0, separator);
                var tags = img.Substring(separator + 1).Trim();
                //repository.Add(new ImageInfo()
                //{
                //    Title = name,
                //    Description = tags
                //});
            }
        }

        public void DeleteImage(int id)
        {

        }
    }
}