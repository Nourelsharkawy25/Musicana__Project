using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicana.Api.Models;

namespace Musicana.Api.Data.Configuration;

public class Musician_InstrumentConfig : IEntityTypeConfiguration<Musician_Instrument>
{
    public void Configure(EntityTypeBuilder<Musician_Instrument> builder)
    {
        builder.HasKey(mi => new { mi.MusicianId, mi.InstrumentId });
        builder.ToTable("Musician_Instruments");

        builder.HasOne(mi => mi.Musician).WithMany(m => m.musician_Instruments).HasForeignKey(mi => mi.MusicianId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(mi => mi.Instrument).WithMany(i => i.musician_Instruments).HasForeignKey(mi => mi.InstrumentId).OnDelete(DeleteBehavior.NoAction);

        builder.HasData(LoadData());
    }

    private static List<Musician_Instrument> LoadData()
    {
        return new List<Musician_Instrument>
        {
            new Musician_Instrument
            {
                MusicianId = 1,
                InstrumentId = 1
            },
            new Musician_Instrument
            {
                MusicianId = 2,
                InstrumentId = 2
            },
            new Musician_Instrument
            {
                MusicianId = 3,
                InstrumentId = 3
            },
            new Musician_Instrument
            {
                MusicianId = 4,
                InstrumentId = 4
            },
            new Musician_Instrument
            {
                MusicianId = 1,
                InstrumentId = 2
            },
            new Musician_Instrument
            {
                MusicianId = 2,
                InstrumentId = 3
            },
            new Musician_Instrument
            {
                MusicianId = 3,
                InstrumentId = 4
            },
            new Musician_Instrument
            {
                MusicianId = 4,
                InstrumentId = 1
            }
        };
    }
}