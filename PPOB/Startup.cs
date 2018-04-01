using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPOB.Startup))]
namespace PPOB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
