using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("customer");

        builder.HasIndex(e => e.IdCityFk, "FK_IdCity");

        builder.HasIndex(e => e.IdPersonTypeFk, "FK_IdPersonType");

        builder.HasIndex(e => e.IdentiNumber, "IdentiNumber").IsUnique();

        builder.Property(e => e.IdentiNumber).HasMaxLength(50);
        builder.Property(e => e.Name).HasMaxLength(50);

        builder.HasOne(d => d.IdCityFkNavigation).WithMany(p => p.Customers)
            .HasForeignKey(d => d.IdCityFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IdCity");

        builder.HasOne(d => d.IdPersonTypeFkNavigation).WithMany(p => p.Customers)
            .HasForeignKey(d => d.IdPersonTypeFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IdPersonType");
    }
}