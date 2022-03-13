﻿using AllAboutGames.Data.Models;
using AllAboutGames.Data.Models.Forum;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AllAboutGames.Data.DataContext
{
    public class AllAboutGamesDataContext : DbContext
    {
        public AllAboutGamesDataContext(DbContextOptions<AllAboutGamesDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

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
    }
}
