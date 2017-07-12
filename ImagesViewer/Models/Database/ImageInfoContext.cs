using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ImagesViewer.Models.Database
{
    public class ImageInfoContext : DbContext
    {
        public DbSet<ImageInfo> Images { get; set; }
    }
}