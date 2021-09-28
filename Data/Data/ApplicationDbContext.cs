using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.PostModels;
using CardDungeonBlazor.Data.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardDungeonBlazor.Data
    {
    public class ApplicationDbContext : IdentityDbContext
        {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
              : base(options)
            {
            this.SetUsers(users);
            }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardDeck> CardDecks { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

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
            base.OnModelCreating(builder);

            builder
                .Entity<Comment>()
                .HasOne(d => d.PostedByUser)
                .WithMany(u => u.Comments)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);

            builder
                .Entity<Post>()
                .HasOne(d => d.PostedByUser)
                .WithMany(u => u.Posts)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
            }
        }
    }
