using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_app.Startup))]
namespace MVC_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
