﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ImagesViewer.Models.Services;

namespace ImagesViewer.Controllers
{
    public class RecognitionController : ApiController
    {
        private readonly RecognitionService service;

        public RecognitionController(RecognitionService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<IHttpActionResult> RegonizeImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var labels = "";
            foreach (var file in provider.Contents)
            {
                labels = service.GetLabels(file);
            }

            return Ok(labels);
        }
    }
}
