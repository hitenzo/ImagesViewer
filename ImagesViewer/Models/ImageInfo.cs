using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagesViewer.Models
{
    public class ImageInfo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}