using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpaceSchedule.Startup))]
namespace SpaceSchedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
