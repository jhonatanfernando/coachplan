using CoachPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoachPlan.Data.Context;

public class CoachPlanContext : DbContext
{
    public virtual DbSet<Muscle> Muscles { get; set; }
    public virtual DbSet<Exercise> Exercises { get; set; }

    public CoachPlanContext(DbContextOptions<CoachPlanContext> options)
 : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasOne(d => d.Muscle)
                .WithMany(d => d.Exercises)
                .HasForeignKey(d => d.MuscleId);

            entity.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(200);

        });

        modelBuilder.Entity<Muscle>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(200);
        });
    }
}
