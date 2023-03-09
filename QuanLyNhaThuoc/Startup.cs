using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyNhaThuoc.Startup))]
namespace QuanLyNhaThuoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
