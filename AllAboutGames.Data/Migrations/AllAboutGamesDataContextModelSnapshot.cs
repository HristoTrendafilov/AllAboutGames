﻿// <auto-generated />
using System;
using AllAboutGames.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    [DbContext(typeof(AllAboutGamesDataContext))]
    partial class AllAboutGamesDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUser", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("UserID"));

                    b.Property<long>("CountryID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2022, 9, 22, 14, 31, 59, 826, DateTimeKind.Local).AddTicks(7749));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("UserID");

                    b.HasIndex("CountryID");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUserRole", b =>
                {
                    b.Property<long>("ApplicationUserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("ApplicationUserRoleID"));

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ApplicationUserRoleID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("ApplicationUsersRoles");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Country", b =>
                {
                    b.Property<long>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("CountryID"));

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Iso3")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Developer", b =>
                {
                    b.Property<long>("DeveloperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("DeveloperID"));

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("DeveloperID");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.FeedBack", b =>
                {
                    b.Property<long>("FeedBackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("FeedBackID"));

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("FeedBackID");

                    b.HasIndex("UserID");

                    b.ToTable("FeedBack");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumCategory", b =>
                {
                    b.Property<long>("ForumCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("ForumCategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("ForumCategoryID");

                    b.ToTable("ForumCategories");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumComment", b =>
                {
                    b.Property<long>("ForumCommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("ForumCommentID"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ForumPostID")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ForumCommentID");

                    b.HasIndex("ForumPostID");

                    b.HasIndex("UserID");

                    b.ToTable("ForumComments");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumLike", b =>
                {
                    b.Property<long>("ForumLikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("ForumLikeID"));

                    b.Property<long>("ForumPostID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ForumLikeID");

                    b.HasIndex("ForumPostID");

                    b.HasIndex("UserID");

                    b.ToTable("ForumLikes");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumPost", b =>
                {
                    b.Property<long>("ForumPostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("ForumPostID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ForumCategoryID")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ForumPostID");

                    b.HasIndex("ForumCategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("ForumPosts");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Game", b =>
                {
                    b.Property<long>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("GameID"));

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeveloperID")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TrailerUrl")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Website")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("GameID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GameGenre", b =>
                {
                    b.Property<long>("GameGenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("GameGenreID"));

                    b.Property<long>("GameID")
                        .HasColumnType("bigint");

                    b.Property<long>("GenreID")
                        .HasColumnType("bigint");

                    b.HasKey("GameGenreID");

                    b.HasIndex("GameID");

                    b.HasIndex("GenreID");

                    b.ToTable("GamesGenres");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GamePlatform", b =>
                {
                    b.Property<long>("GamePlatformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("GamePlatformID"));

                    b.Property<long>("GameID")
                        .HasColumnType("bigint");

                    b.Property<long>("PlatformID")
                        .HasColumnType("bigint");

                    b.HasKey("GamePlatformID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlatformID");

                    b.ToTable("GamesPlatforms");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Genre", b =>
                {
                    b.Property<long>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("GenreID"));

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Platform", b =>
                {
                    b.Property<long>("PlatformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("PlatformID"));

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("DeveloperID")
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PlatformID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Rating", b =>
                {
                    b.Property<long>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("RatingID"));

                    b.Property<long>("GameID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("RatingID");

                    b.HasIndex("GameID");

                    b.HasIndex("UserID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Review", b =>
                {
                    b.Property<long>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("ReviewID"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("GameID")
                        .HasColumnType("bigint");

                    b.Property<long>("RatingID")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ReviewID");

                    b.HasIndex("GameID");

                    b.HasIndex("RatingID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Role", b =>
                {
                    b.Property<long>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("RoleID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.FeedBack", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("FeedBacks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumComment", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Forum.ForumPost", "ForumPost")
                        .WithMany("ForumComments")
                        .HasForeignKey("ForumPostID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("ForumComments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ForumPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumLike", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Forum.ForumPost", "ForumPost")
                        .WithMany("ForumLikes")
                        .HasForeignKey("ForumPostID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ForumPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumPost", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Forum.ForumCategory", "ForumCategory")
                        .WithMany("ForumPosts")
                        .HasForeignKey("ForumCategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("ForumPosts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ForumCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Game", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GameGenre", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Genre", "Genre")
                        .WithMany("GamesGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.GamePlatform", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Platform", "Platform")
                        .WithMany("GamesPlatforms")
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Platform", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Rating", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("Ratings")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Review", b =>
                {
                    b.HasOne("AllAboutGames.Data.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AllAboutGames.Data.Models.ApplicationUser", "ReviewedBy")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Rating");

                    b.Navigation("ReviewedBy");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("FeedBacks");

                    b.Navigation("ForumComments");

                    b.Navigation("ForumPosts");

                    b.Navigation("Ratings");

                    b.Navigation("Reviews");

                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Developer", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumCategory", b =>
                {
                    b.Navigation("ForumPosts");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Forum.ForumPost", b =>
                {
                    b.Navigation("ForumComments");

                    b.Navigation("ForumLikes");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Game", b =>
                {
                    b.Navigation("GameGenres");

                    b.Navigation("GamePlatforms");

                    b.Navigation("Ratings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Genre", b =>
                {
                    b.Navigation("GamesGenres");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Platform", b =>
                {
                    b.Navigation("GamesPlatforms");
                });

            modelBuilder.Entity("AllAboutGames.Data.Models.Role", b =>
                {
                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
