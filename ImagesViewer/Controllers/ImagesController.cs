﻿using System;
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
using System.Web.Mvc;
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

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddImages()
        {
            //var contentFile = Request.Content.ReadAsByteArrayAsync();
            //var textBytes = contentFile.Result;
            //string result = Encoding.UTF8.GetString(textBytes);
            //File.WriteAllText(@"C:\Users\hitenz\Desktop\WriteText.txt", result);


            //var request = HttpContext.Current.Request;
            //var filePath = @"C:\Users\hitenz\Desktop\WriteText.txt";
            //using (var fs = new FileStream(filePath, FileMode.Create))
            //{
            //    request.InputStream.CopyTo(fs);
            //}

            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();
                //Do whatever you want with filename and its binaray data.
            }

            return Ok();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult DeleteImage()
        {
            return Ok();
        }
    }
}
