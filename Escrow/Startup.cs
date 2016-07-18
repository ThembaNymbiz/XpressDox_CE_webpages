using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escrow.Startup))]
namespace Escrow
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
