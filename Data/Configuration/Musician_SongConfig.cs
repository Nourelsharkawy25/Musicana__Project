using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicana.Api.Models;

namespace Musicana.Api.Data.Configuration;

public class Musician_SongConfig : IEntityTypeConfiguration<Musician_Song>
{
    public void Configure(EntityTypeBuilder<Musician_Song> builder)
    {
        builder.HasKey(ms => new { ms.MusicianId, ms.SongId });
        builder.ToTable("Musician_Songs");

        builder.HasOne(ms => ms.Musician).WithMany(m => m.musician_Songs).HasForeignKey(ms => ms.MusicianId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(ms => ms.Song).WithMany(s => s.musician_Songs).HasForeignKey(ms => ms.SongId).OnDelete(DeleteBehavior.Cascade);

        builder.HasData(LoadData());
    }

    private List<Musician_Song> LoadData()
    {
        return new List<Musician_Song>
        {
            new Musician_Song
            {
                MusicianId = 1,
                SongId = 1
            },
            new Musician_Song
            {
                MusicianId = 2,
                SongId = 2
            },
            new Musician_Song
            {
                MusicianId = 3,
                SongId = 3
            },
            new Musician_Song
            {
                MusicianId = 4,
                SongId = 4
            },
            new Musician_Song
            {
                MusicianId = 1,
                SongId = 2
            },
            new Musician_Song
            {
                MusicianId = 2,
                SongId = 3
            },
            new Musician_Song
            {
                MusicianId = 3,
                SongId = 4
            },
            new Musician_Song
            {
                MusicianId = 4,
                SongId = 1
            }
        };
    }
}