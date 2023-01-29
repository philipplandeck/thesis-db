using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Areas.Identity.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Thesis> Thesis { get; set; }
    public DbSet<Supervisor> Supervisor { get; set; }
    public DbSet<ProgramModel> Program { get; set; }
    public DbSet<Chair> Chair { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*
         * One-to-many relationships according to
         * https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
         */
        modelBuilder.Entity<Supervisor>()
            .HasOne(s => s.Chair)
            .WithMany(c => c.Supervisors)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Chair)
            .WithMany(c => c.Users)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Thesis>()
            .HasOne(t => t.Supervisor)
            .WithMany(s => s.Theses)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        string adminUsername = "admin@thesis.de";
        string adminPassword = "admin";
        AppUser user = new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Hans",
            LastName = "Meier",
            Activity = AppUser.ActivityType.active,
            UserName = adminUsername,
            NormalizedUserName = adminUsername.ToUpper(),
            Email = adminUsername,
            NormalizedEmail = adminUsername.ToUpper()
        };
        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
        user.PasswordHash = hasher.HashPassword(user, adminPassword);
        modelBuilder.Entity<AppUser>().HasData(user);

        IdentityRole role = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        role.NormalizedName = role.Name.ToUpper();
        modelBuilder.Entity<IdentityRole>().HasData(role);

        IdentityUserRole<string> ur = new IdentityUserRole<string> { UserId = user.Id, RoleId = role.Id };
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(ur);

        List<ProgramModel.ProgramType> programs = Enum.GetValues(typeof(ProgramModel.ProgramType)).Cast<ProgramModel.ProgramType>().ToList();
        foreach (ProgramModel.ProgramType program in programs)
        {
            modelBuilder.Entity<ProgramModel>().HasData(new ProgramModel()
            {
                Id = programs.IndexOf(program) + 1,
                Name = program
            });
        }
    }
}
