using System.Web.Mvc;
using ImagesViewer.Models.Database;
using ImagesViewer.Models.Repositories;
using ImagesViewer.Models.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace ImagesViewer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ImageService, ImageService>();
            container.RegisterType<IImagesRepository, ImagesRepository>();
            container.RegisterType<ImageInfoContext, ImageInfoContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}