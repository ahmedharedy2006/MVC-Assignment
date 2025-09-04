using System;

using Microsoft.EntityFrameworkCore;
using MVC_Assignment.Models;

namespace MVC_Assignment.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Departments
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Computer Science" },
            new Department { Id = 2, Name = "Mathematics" },
            new Department { Id = 3, Name = "Physics" }
        );

        // Seed Students
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "Alice", Address = "123 Main St", Age = 20, DepartmentId = 1 },
            new Student { Id = 2, Name = "Bob", Address = "456 Elm St", Age = 22, DepartmentId = 2 },
            new Student { Id = 3, Name = "Charlie", Address = "789 Oak St", Age = 21, DepartmentId = 3 }
        );
    }
}
