using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EC.Web.Startup))]
namespace EC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
