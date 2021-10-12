using System.Linq;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CardDungeonBlazor.Infrastructure
    {
    public static class ApplicationBuilderExtentions
        {
        public static IApplicationBuilder PrepareDatabase (
              this IApplicationBuilder app )
            {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            ApplicationDbContext data = scopedServices.ServiceProvider.GetService<ApplicationDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
            }

        private static void SeedCategories ( ApplicationDbContext data )
            {
            if (data.CardTypes.Any())
                {
                return;
                }

            data.CardTypes.AddRange(new[]
            {
                        new CardType { Name = "Attack"},
                        new CardType { Name = "Deffence"},
                        new CardType { Name = "Heal"},
                        new CardType { Name = "Poison"}
            });
            data.SaveChanges();
            }
        }
    }
