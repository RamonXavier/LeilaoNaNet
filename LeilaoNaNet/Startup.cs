using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeilaoNaNet.Startup))]
namespace LeilaoNaNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}