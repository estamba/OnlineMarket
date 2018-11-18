using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineMarket.Startup))]
namespace OnlineMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //UnityConfig.RegisterComponents();

            ConfigureAuth(app);
        }
    }
}
