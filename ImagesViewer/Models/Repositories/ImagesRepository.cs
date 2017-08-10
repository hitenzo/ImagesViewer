using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ImagesViewer.Models.Database;

namespace ImagesViewer.Models.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ImageInfoContext context;

        public ImagesRepository(ImageInfoContext context)
        {
            this.context = context;
        }

        public ImageInfo GetById(int id)
        {
            return context.Images.FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<ImageInfo> GetAll()
        {
            return context.Images;
        }

        public void Add(ImageInfo item)
        {
            context.Images.Add(item);
            SaveChanges();
        }

        public void Remove(int id)
        {
            var item = GetById(id);
            context.Images.Remove(item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}