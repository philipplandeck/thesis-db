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
    public DbSet<AppUser> AppUser { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
        AppUser user = new AppUser() { Id = Guid.NewGuid().ToString(), UserName = "admin@thesis.de" };
        user.NormalizedUserName = user.UserName.ToUpper();
        user.PasswordHash = hasher.HashPassword(user, "admin");
        builder.Entity<AppUser>().HasData(user);

        IdentityRole role = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        role.NormalizedName = role.Name.ToUpper();
        builder.Entity<IdentityRole>().HasData(role);

        IdentityUserRole<string> ur = new IdentityUserRole<string> { UserId = user.Id, RoleId = role.Id };
        builder.Entity<IdentityUserRole<string>>().HasData(ur);

        List<ProgramModel.ProgramType> programTypes = Enum.GetValues(typeof(ProgramModel.ProgramType)).Cast<ProgramModel.ProgramType>().ToList();
        foreach (ProgramModel.ProgramType program in programTypes)
        {
            builder.Entity<ProgramModel>().HasData(new ProgramModel()
            {
                Id = programTypes.IndexOf(program) + 1,
                Name = program
            });
        }
    }
}
