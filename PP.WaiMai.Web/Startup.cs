using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PP.WaiMai.Web.Startup))]
namespace PP.WaiMai.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
