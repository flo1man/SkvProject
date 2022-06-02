using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SkvProject.Web.Areas.Identity.IdentityHostingStartup))]
namespace SkvProject.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
