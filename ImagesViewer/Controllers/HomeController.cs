using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImagesViewer.Models;
using ImagesViewer.Models.Database;
using ImagesViewer.Models.Repositories;

namespace ImagesViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}