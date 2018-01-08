using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NumberPlates.Startup))]
namespace NumberPlates
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
