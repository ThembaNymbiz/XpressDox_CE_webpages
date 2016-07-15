using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chattan_Deposit_Form.Startup))]
namespace Chattan_Deposit_Form
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
