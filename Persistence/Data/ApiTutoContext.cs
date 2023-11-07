using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class ApiTutoContext : DbContext
{
    public ApiTutoContext()
    {
    }

    public ApiTutoContext(DbContextOptions<ApiTutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Persontype> Persontypes { get; set; }

    public virtual DbSet<State> States { get; set; }

    /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=4capasTuto", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
     */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
