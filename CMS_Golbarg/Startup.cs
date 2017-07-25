using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS_Golbarg.Startup))]
namespace CMS_Golbarg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }


}
