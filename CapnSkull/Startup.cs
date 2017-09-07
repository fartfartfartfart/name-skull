using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapnSkull.Startup))]
namespace CapnSkull
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
