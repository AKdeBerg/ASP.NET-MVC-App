using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Berg_Book_House.Startup))]
namespace Berg_Book_House
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
