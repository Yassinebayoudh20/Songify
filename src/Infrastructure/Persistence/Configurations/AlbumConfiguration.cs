using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projects.Domain.Entities;

namespace projects.Infrastructure.Persistence.Configurations;
internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Image).HasColumnType("image");

        builder.HasOne(p => p.Artist).WithMany(p => p.Albums);
        builder.HasMany(a => a.Songs).WithOne(a => a.Album).OnDelete(DeleteBehavior.Cascade);
    }
}
