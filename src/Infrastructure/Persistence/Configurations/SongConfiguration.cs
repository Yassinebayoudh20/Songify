using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projects.Domain.Entities;

namespace projects.Infrastructure.Persistence.Configurations;
public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.Property(p => p.Title).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Image).HasColumnType("image");

        builder.HasOne(a => a.Album).WithMany(s => s.Songs);
    }
}
