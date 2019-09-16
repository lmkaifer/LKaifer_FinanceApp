using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LKaifer_FinanceApp.Startup))]
namespace LKaifer_FinanceApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
