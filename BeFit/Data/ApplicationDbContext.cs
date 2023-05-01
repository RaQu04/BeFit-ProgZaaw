using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;
using Microsoft.AspNetCore.Identity;

namespace BeFit.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<BeFit.Models.ExerciseType>? ExerciseType { get; set; }
    public DbSet<BeFit.Models.Exercise>? Exercise { get; set; }
    public DbSet<BeFit.Models.Session>? Session { get; set; }
    public DbSet<BeFit.Models.Statistic>? Statistic { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

        //seed admin role
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "Admin".ToUpper(),
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });

        //create user
        var appUser = new IdentityUser
        {
            Id = ADMIN_ID,
            Email = "admin@c.pl",
            EmailConfirmed = true,
            UserName = "admin@c.pl",
            NormalizedUserName = "admin@c.pl".ToUpper()
        };

        //set user password
        PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "Haslo123$");

        //seed user
        builder.Entity<IdentityUser>().HasData(appUser);

        //set user role to admin
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ROLE_ID,
            UserId = ADMIN_ID
        });
    }
}
