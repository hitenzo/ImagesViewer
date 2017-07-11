using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImagesViewer.Startup))]
namespace ImagesViewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
