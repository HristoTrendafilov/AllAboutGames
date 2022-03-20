using AllAboutGames.Data.Models;
using AllAboutGames.Data.Models.Forum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

#nullable disable

namespace AllAboutGames.Data.DataContext
{
    public class AllAboutGamesDataContext : DbContext
    {
        public AllAboutGamesDataContext(DbContextOptions<AllAboutGamesDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            this.RemoveCascadeDeletion(modelBuilder);
            this.CreateDefaultValues(modelBuilder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<GameGenre> GamesGenres { get; set; }
        public DbSet<GamePlatform> GamesPlatforms { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumComment> ForumComments { get; set; }
        public DbSet<ForumLike> ForumLikes { get; set; }
        public DbSet<Role> Roles { get; set; }

        private void CreateDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.CreatedOn).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Developer>().Property(x => x.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Game>().Property(x => x.IsDeleted).HasDefaultValue(false);
        }

        private void RemoveCascadeDeletion(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();
            var foreignKeys = entityTypes.SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
