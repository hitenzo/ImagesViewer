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

        public void AddImage(ImageInfo image)
        {
            
        }

        public void DeleteImage(int id)
        {
            
        }
    }
}