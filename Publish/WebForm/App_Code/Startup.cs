using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryManagement_WebPortal.Startup))]
namespace InventoryManagement_WebPortal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
