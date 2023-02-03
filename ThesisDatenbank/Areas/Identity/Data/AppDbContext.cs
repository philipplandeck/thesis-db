using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Areas.Identity.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Chair> Chair { get; set; }
    public DbSet<Supervisor> Supervisor { get; set; }
    public DbSet<Thesis> Thesis { get; set; }
    public DbSet<ProgramModel> Program { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Supervisor>()
            .HasOne(s => s.Chair)
            .WithMany(c => c.Supervisors)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Chair)
            .WithMany(c => c.Users)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Thesis>()
            .HasOne(t => t.Supervisor)
            .WithMany(s => s.Theses)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        List<string> chairs = new()
        {
            "BWL und Wirtschaftsinformatik",
            "Wirtschaftsinformatik und Systementwicklung",
            "Wirtschaftsinformatik und Business Analytics",
            "Prozess- und IT-Integration für KI im Unternehmen"
        };
        foreach (string chair in chairs)
        {
            modelBuilder.Entity<Chair>().HasData(new Chair()
            {
                Id = chairs.IndexOf(chair) + 1,
                Name = chair
            });
        }

        List<ProgramModel.ProgramType> programs = Enum.GetValues(typeof(ProgramModel.ProgramType)).Cast<ProgramModel.ProgramType>().ToList();
        foreach (ProgramModel.ProgramType program in programs)
        {
            modelBuilder.Entity<ProgramModel>().HasData(new ProgramModel()
            {
                Id = programs.IndexOf(program) + 1,
                Name = program
            });
        }

        string adminUsername = "admin@thesis.de";
        string adminPassword = "admin";
        AppUser user = new()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Hans",
            LastName = "Meier",
            ChairId = 2,
            UserName = adminUsername,
            NormalizedUserName = adminUsername.ToUpper(),
            Email = adminUsername,
            NormalizedEmail = adminUsername.ToUpper()
        };
        PasswordHasher<AppUser> hasher = new();
        user.PasswordHash = hasher.HashPassword(user, adminPassword);
        modelBuilder.Entity<AppUser>().HasData(user);

        IdentityRole role = new() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        role.NormalizedName = role.Name.ToUpper();
        modelBuilder.Entity<IdentityRole>().HasData(role);

        IdentityUserRole<string> ur = new() { UserId = user.Id, RoleId = role.Id };
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(ur);
    }
}
