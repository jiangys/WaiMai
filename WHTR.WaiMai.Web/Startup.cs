using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WHTR.WaiMai.Web.Startup))]
namespace WHTR.WaiMai.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
