using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ControllerApi.Entities;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=pg-14b5c807-code-first.g.aivencloud.com;Port=21029;Database=codeFirst;Username=avnadmin;Password=AVNS_ps0KiO6cGJgDYVqvfEl;SSL Mode=Require;");
    }
}
