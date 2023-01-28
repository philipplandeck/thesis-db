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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

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
        builder.Entity<AppUser>().HasData(user);

        IdentityRole role = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        role.NormalizedName = role.Name.ToUpper();
        builder.Entity<IdentityRole>().HasData(role);

        IdentityUserRole<string> ur = new IdentityUserRole<string> { UserId = user.Id, RoleId = role.Id };
        builder.Entity<IdentityUserRole<string>>().HasData(ur);

        List<ProgramModel.ProgramType> programs = Enum.GetValues(typeof(ProgramModel.ProgramType)).Cast<ProgramModel.ProgramType>().ToList();
        foreach (ProgramModel.ProgramType program in programs)
        {
            builder.Entity<ProgramModel>().HasData(new ProgramModel()
            {
                Id = programs.IndexOf(program) + 1,
                Name = program
            });
        }

        /* According to
         * https://learn.microsoft.com/en-us/ef/core/saving/cascade-delete
        
        builder.
            Entity<Chair>()
            .HasMany(s => s.Supervisors)
            .WithOne(x => x.Chair)
            .OnDelete(DeleteBehavior.ClientCascade); */
    }
}
