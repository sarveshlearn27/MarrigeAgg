using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarrigerAggrigator.Startup))]
namespace MarrigerAggrigator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
