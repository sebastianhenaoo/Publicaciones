using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facebook4532.Startup))]
namespace Facebook4532
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
