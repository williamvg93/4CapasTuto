using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class PersonTypeConfig : IEntityTypeConfiguration<Persontype>
{
    public void Configure(EntityTypeBuilder<Persontype> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("persontype");

        builder.HasIndex(e => e.Name, "Name").IsUnique();

        builder.Property(e => e.Name).HasMaxLength(50);
    }
}