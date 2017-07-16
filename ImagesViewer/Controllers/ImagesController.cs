using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult AddImage()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteImage()
        {
            return Ok();
        }
    }
}
