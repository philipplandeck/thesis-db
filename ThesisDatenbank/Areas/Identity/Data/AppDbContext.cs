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
    // public DbSet<Program> Programs { get; set; } Fehler!!
    public DbSet<Chair> Chair { get; set; }
    public DbSet<AppUser> AppUser { get; set; }
    public DbSet<Supervisor> Supervisor { get; set; }


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
    }
}
