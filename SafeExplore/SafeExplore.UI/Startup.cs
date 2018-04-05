using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafeExplore.UI.Startup))]
namespace SafeExplore.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
