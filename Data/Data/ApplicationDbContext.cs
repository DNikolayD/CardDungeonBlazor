using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardDungeonBlazor.Data
    {
    public class ApplicationDbContext : IdentityDbContext
        {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
              : base(options)
            {
            this.SetUsers(this.users);
            }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardDeck> CardDecks { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Image> Images { get; set; }

        private DbSet<ApplicationUser> users;

        public DbSet<ApplicationUser> GetUsers ()
            {
            return this.users;
            }

        public void SetUsers ( DbSet<ApplicationUser> value )
            {
            this.users = value;
            }

        protected override void OnModelCreating ( ModelBuilder builder )
            {
            builder
                  .Entity<Comment>()
                  .HasOne(c => c.Post)
                  .WithMany(c => c.Comments)
                  .HasForeignKey(c => c.PostId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Deck>()
                .HasOne(d => d.CreatedByUser)
                .WithMany(u => u.CreatedDecks)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasOne(c => c.PostedByUser)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Post>()
                .HasOne(p => p.PostedByUser)
                .WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Card>()
                .HasOne(c => c.Image)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasMany(c => c.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Post>()
                .HasMany(p => p.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            }
        }
    }
