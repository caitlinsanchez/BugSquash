using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BugSquash.Startup))]
namespace BugSquash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
