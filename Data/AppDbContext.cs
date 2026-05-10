using Microsoft.EntityFrameworkCore;
using MioMizutani_Lab3.Models;
using Microsoft.AspNetCore.Identity;

namespace MioMizutani_Lab3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<SubscriptionPlanModule> SubscriptionPlanModules { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SubscriptionPlanModule>()
            .HasKey(spm => new { spm.PlanId, spm.ModuleId });
    }
}