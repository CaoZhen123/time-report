using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeRecordSystem1.Startup))]
namespace TimeRecordSystem1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
