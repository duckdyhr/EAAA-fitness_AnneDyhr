using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessUsers.Startup))]
namespace FitnessUsers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
