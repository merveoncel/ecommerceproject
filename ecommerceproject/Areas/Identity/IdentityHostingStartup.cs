using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ecommerceproject.Areas.Identity.IdentityHostingStartup))]
namespace ecommerceproject.Areas.Identity
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