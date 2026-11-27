using Group5API.Models;
using Microsoft.EntityFrameworkCore;

public class Group5APIContext(DbContextOptions<Group5APIContext> options) : DbContext(options)
{
    public DbSet<Group5API.Models.TeamMember> TeamMember { get; set; } = default!;
    public DbSet<Group5API.Models.Snacks> Snacks { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { Id = 1, Name = "Kyle Rosa", Email = "rosake@mail.uc.edu", Major = "Cybersecurity", Year = "Senior" },
            new TeamMember { Id = 2, Name = "Marley Chilenski", Email = "chilenme@mail.uc.edu", Major = "Software Application Development", Year = "Junior" },
            new TeamMember { Id = 3, Name = "Claire Battelle", Email = "battelci@mail.uc.edu", Major = "Software Application Development", Year = "Sophomore" },
            new TeamMember { Id = 4, Name = "Deshyah Anderson", Email = "ander3dy@mail.uc.edu", Major = "Software Application Development", Year = "Junior" }
        );

        modelBuilder.Entity<Snacks>().HasData(
            new Snacks { ID = 1, firstName = "Claire", lastName = "Battelle", favSnack = "Ritz"},
            new Snacks { ID = 2, firstName = "Marley", lastName = "Chilenski", favSnack = "Goldfish"},
            new Snacks { ID = 3, firstName = "Kyle", lastName = "Rosa", favSnack = "Goldfish"},
            new Snacks { ID = 4, firstName = "Deshyah", lastName = "Anderson", favSnack = "Oreos"}
            );

    }
}
