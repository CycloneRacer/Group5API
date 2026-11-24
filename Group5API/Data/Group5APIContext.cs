using Group5API.Models;
using Microsoft.EntityFrameworkCore;

public class Group5APIContext(DbContextOptions<Group5APIContext> options) : DbContext(options)
{
    public DbSet<Group5API.Models.TeamMember> TeamMember { get; set; } = default!;
    public DbSet<Group5API.Models.FavoriteMovie> FavoriteMovie { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { Id = 1, Name = "Kyle Rosa", Email = "rosake@mail.uc.edu", Major = "Cybersecurity", Year = "Senior" },
            new TeamMember { Id = 2, Name = "Marley Chilenski", Email = "chilenme@mail.uc.edu", Major = "Software Application Development", Year = "Junior" },
            new TeamMember { Id = 3, Name = "Claire Battelle", Email = "battelci@mail.uc.edu", Major = "Software Application Development", Year = "Sophomore" },
            new TeamMember { Id = 4, Name = "Deshyah Anderson", Email = "ander3dy@mail.uc.edu", Major = "Software Application Development", Year = "Junior" }
        );

        modelBuilder.Entity<FavoriteMovie>().HasData(
                new FavoriteMovie { Id = 1, Title = "Coraline", Director = "Henry Selick", Genre = "Animation", ReleaseYear = 2009, Rating = 7.8 },
                new FavoriteMovie { Id = 2, Title = "Bridesmaids", Director = "Paul Feig", Genre = "Comedy", ReleaseYear = 2011, Rating = 6.8 },
                new FavoriteMovie { Id = 3, Title = "Other Mommy", Director = "Rob Savage", Genre = "Horror", ReleaseYear = 2026, Rating = 7.2 },
                new FavoriteMovie { Id = 4, Title = "Spider-Man: Into the Spider-Verse", Director = "Bob Persichetti", Genre = "Animation", ReleaseYear = 2018, Rating = 8.4 },
                new FavoriteMovie { Id = 5, Title = "Get Out", Director = "Jordan Peele", Genre = "Horror", ReleaseYear = 2017, Rating = 7.8 },
                new FavoriteMovie { Id = 6, Title = "The Lego Movie", Director = "Phil Lord", Genre = "Animation", ReleaseYear = 2014, Rating = 7.7 }
                );
    }
}
