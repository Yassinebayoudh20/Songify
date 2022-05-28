using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projects.Domain.Entities;

namespace projects.Infrastructure.Persistence.Configurations;
public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Photo).HasColumnType("image");

        builder.HasMany(p => p.Albums).WithOne(p => p.Artist);
    }
}
