using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PostProject.Startup))]
namespace PostProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
