using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crm.Startup))]
namespace Crm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
