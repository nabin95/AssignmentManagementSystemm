using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentManagementSystem.Startup))]
namespace AssignmentManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
