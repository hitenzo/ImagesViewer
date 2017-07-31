using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ImagesViewer.Models.Services;

namespace ImagesViewer.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly ImageService service;

        public ImagesController(ImageService service)
        {
            this.service = service;
        }

        public IHttpActionResult GetAllImages()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddImages(List<string> tags)
        {
            var x = tags;
            

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteImage()
        {
            return Ok();
        }
    }
}
