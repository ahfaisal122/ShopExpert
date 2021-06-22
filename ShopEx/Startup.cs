using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopEx.Startup))]
namespace ShopEx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
