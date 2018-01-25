using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealarship.UI.Startup))]
namespace CarDealarship.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
