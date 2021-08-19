using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunit;
using Microsoft.AspNetCore.Components;
using Moq;
using Services.ServiceModels.CardsModels;
using Services.Services;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using CardDungeonBlazor.Areas.Cards.Views;
using Microsoft.EntityFrameworkCore;
using CardDungeonBlazor.Data;
using Microsoft.Extensions.Configuration;

namespace Test
    {
    public class AddCardsTest : TestContext
        {
        [Fact]
        public void AddingCards ()
            {
            Mock<IConfiguration> mockConfiguration = new();
            DbContextOptions<ApplicationDbContext> options = new();
            ApplicationDbContext mockBase = new(options);
            this.Services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(
                        mockConfiguration.Object.GetConnectionString("DefaultConnection")));
            mockBase.CardTypes.Add(
                new CardDungeonBlazor.Data.Models.CardModels.CardType
                    {
                    Id = 1,
                    Name = "Attack",
                    }
                );
            Mock<CardServiceModel> mockServiceModel = new();
            Mock<CardsService> mockService = new();
            Mock<NavigationManager> mockNavigation = new();
            this.Services.AddTransient<CardsService>();
            //this.Services.AddTransient<NavigationManager>();

            IRenderedComponent<AddCard> commponent = this.RenderComponent<AddCard>();
            mockService.Verify(m => m.Add(new AddCardsServiceModel
                {
                CardTypeId = It
                .IsAny<int>(),
                CardTypes = It.IsAny<List<CardTypeServiceModel>>(),
                Cost = It.IsAny<int>(),
                Description = It.IsAny<string>(),
                ImageUrl = It.IsAny<string>(),
                Name = It.IsAny<string>(),
                Value = It
                .IsAny<int>(),
                }), Times.Once);
            }
        }
    }
