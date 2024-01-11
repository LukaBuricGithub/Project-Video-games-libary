using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectBuricLuka.Model;

namespace ProjectBuricLuka.DAL
{
    public class VideoGamesDbContext : IdentityDbContext<AppUser>
    {
        public VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CityProject> Cities { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            //Countries
            modelBuilder.Entity<Country>().HasData(new Country { ID = 1, Name = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 2, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 3, Name = "England" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 4, Name = "Canada" });

            //Cities
            modelBuilder.Entity<CityProject>().HasData(new CityProject { ID = 1, Name = "Lyon",CountryID = 2});
            modelBuilder.Entity<CityProject>().HasData(new CityProject { ID = 2, Name = "Montreal", CountryID = 4 });
            modelBuilder.Entity<CityProject>().HasData(new CityProject { ID = 3, Name = "Irvin", CountryID = 1 });

            //Publishers
            modelBuilder.Entity<Publisher>().HasData(new Publisher { ID = 1, Name = "Bethesda Softworks",CountryID=1 });
            modelBuilder.Entity<Publisher>().HasData(new Publisher { ID = 2, Name = "Ubisoft", CountryID = 2 });

            //Developers
            modelBuilder.Entity<Developer>().HasData(new Developer { ID = 1, Name = "Arkane studios", Website = "https://www.arkane-studios.com/en", CityProjectID = 1, YearFounded = 1999 });
            modelBuilder.Entity<Developer>().HasData(new Developer { ID = 2, Name = "Ubisoft Montreal", Website = "https://montreal.ubisoft.com/en/", CityProjectID = 2, YearFounded = 1997 });
            modelBuilder.Entity<Developer>().HasData(new Developer { ID = 3, Name = "Obsidian Entertainment", Website = "https://www.obsidian.net/", CityProjectID = 3, YearFounded = 2003 });


            //VideoGames
            modelBuilder.Entity<VideoGame>().HasData(new VideoGame { ID = 1, Name = "Tom Clancy's Rainbow Six Siege", DeveloperID = 2, PublisherID = 2, Website = "https://www.ubisoft.com/en-gb/game/rainbow-six/siege",Genre="FPS, Multiplayer, Team-based, Action",Rating=7.9,ReleaseDate=new DateTime(2015,12,15) });
            modelBuilder.Entity<VideoGame>().HasData(new VideoGame { ID = 2, Name = "Prey", DeveloperID = 1, PublisherID = 1, Website = "https://bethesda.net/en/game/prey", Genre = "FPS, Sci-fi, Space, Immersive Sim, Singleplayer", Rating = 8.2, ReleaseDate = new DateTime(2017, 5, 4) });
            modelBuilder.Entity<VideoGame>().HasData(new VideoGame { ID = 3, Name = "Fallout: New Vegas", DeveloperID = 3, PublisherID = 1, Website = "https://fallout.bethesda.net/en/games/fallout-new-vegas", Genre = "Open World, Post-apocalyptic, RPG, Singleplayer", Rating = 8.4, ReleaseDate = new DateTime(2010, 10, 22) });




        }

    }
}
