using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PriceConfig.Startup))]
namespace PriceConfig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
