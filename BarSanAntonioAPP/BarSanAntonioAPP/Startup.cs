using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarSanAntonioAPP.Startup))]
namespace BarSanAntonioAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
