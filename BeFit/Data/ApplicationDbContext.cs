using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;

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
}

