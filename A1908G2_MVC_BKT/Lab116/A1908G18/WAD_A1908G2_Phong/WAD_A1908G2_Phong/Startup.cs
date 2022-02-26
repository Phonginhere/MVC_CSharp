using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WAD_A1908G2_Phong.Startup))]
namespace WAD_A1908G2_Phong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
