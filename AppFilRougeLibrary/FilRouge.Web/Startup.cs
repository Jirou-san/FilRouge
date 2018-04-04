using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilRouge.Web.Startup))]
namespace FilRouge.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
