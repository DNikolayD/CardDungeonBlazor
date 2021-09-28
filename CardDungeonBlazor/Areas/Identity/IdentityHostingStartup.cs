using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CardDungeonBlazor.Areas.Identity.IdentityHostingStartup))]
namespace CardDungeonBlazor.Areas.Identity
    {
    public class IdentityHostingStartup : IHostingStartup
        {
        public void Configure ( IWebHostBuilder builder )
            {
            builder.ConfigureServices(( context, services ) =>
            {
            });
            }
        }
    }