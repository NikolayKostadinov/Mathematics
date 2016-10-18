using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mathematics.Web.Startup))]
namespace Mathematics.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
