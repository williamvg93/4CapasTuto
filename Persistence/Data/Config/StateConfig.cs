using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class StateConfig : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("state");

        builder.HasIndex(e => e.IdCountryFk, "FK_IdCountry");

        builder.HasIndex(e => e.Name, "Name").IsUnique();

        builder.Property(e => e.Name).HasMaxLength(50);

        builder.HasOne(d => d.IdCountryFkNavigation).WithMany(p => p.States)
            .HasForeignKey(d => d.IdCountryFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IdCountry");
    }
}