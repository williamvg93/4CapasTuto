using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("city");

        builder.HasIndex(e => e.IdStateFk, "FK_IdState");

        builder.HasIndex(e => e.Name, "Name").IsUnique();

        builder.Property(e => e.Name).HasMaxLength(50);

        builder.HasOne(d => d.IdStateFkNavigation).WithMany(p => p.Cities)
            .HasForeignKey(d => d.IdStateFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IdState");
    }
}