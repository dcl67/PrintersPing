using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrintersPing.Startup))]
namespace PrintersPing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
