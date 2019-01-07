using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VehicleFactory.UI.Startup))]
namespace VehicleFactory.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
