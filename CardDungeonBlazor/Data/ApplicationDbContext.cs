using CardDungeonBlazor.Data.Models.CardModles;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDungeonBlazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardDeck> CardDecks { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<CardImage> CardImages { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommetImage> CommetImages { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostImage> PostImages { get; set; }
    }
}
