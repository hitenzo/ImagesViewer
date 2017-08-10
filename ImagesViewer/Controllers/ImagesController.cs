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
using ImagesViewer.Models;
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
            IEnumerable<ImageInfo> images = service.GetAllImages();
            var imagesContent = new List<object>();
            foreach (var img in images)
            {
                imagesContent.Add(new
                {
                    id = img.Id,
                    title = img.Title,
                    description = img.Description,
                    bytes = Convert.ToBase64String(img.ImageBytes)
                });
            }
            return Ok(imagesContent);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddImages()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            service.AddImages(provider.Contents);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteImage([FromBody]int id)
        {
            service.DeleteImage(id);
            return Ok();
        }
    }
}
