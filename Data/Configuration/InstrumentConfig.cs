using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicana.Api.Models;
using Musicana.Api.Enums;

namespace Musicana.Api.Data.Configuration;

public class InstrumentConfig : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.HasKey(i => i.Id);
        builder.ToTable("Instruments");

        builder.Property(i => i.Name).HasMaxLength(30).IsRequired();
        builder.Property(i => i.Description).HasMaxLength(100);
        builder.Property(i => i.IsDeleted).IsRequired();
        builder.Property(i => i.Type).HasMaxLength(20).IsRequired();
        builder.Property(i => i.ImageUrl).HasMaxLength(100).IsRequired();

        builder.HasData(LoadData());
    }

    private static List<Instrument> LoadData()
    {
        return new List<Instrument>
        {
            new Instrument
            {
                Id = 1,
                Name = "Guitar",
                Description = "Description 1",
                IsDeleted = false,
                ImageUrl = "/Instruments/Guitar.jpg",
                Type = InstrumentType.Guitar
            },
            new Instrument
            {
                Id = 2,
                Name = "Piano",
                Description = "Description 2",
                IsDeleted = false,
                ImageUrl = "/Instruments/piano.jpg",
                Type = InstrumentType.Keyboard
            },
            new Instrument
            {
                Id = 3,
                Name = "Piano",
                Description = "Description 3",
                IsDeleted = false,
                ImageUrl = "/Instruments/piano.jpg",
                Type = InstrumentType.Keyboard
            },
            new Instrument
            {
                Id = 4,
                Name = "Piano",
                Description = "Description 4",
                IsDeleted = false,
                ImageUrl = "/Instruments/piano.jpg",
                Type = InstrumentType.Keyboard
            },
            new Instrument
            {
                Id = 5,
                Name = "Piano",
                Description = "Description 5",
                IsDeleted = false,
                ImageUrl = "/Instruments/piano.jpg",
                Type = InstrumentType.Keyboard
            },
            new Instrument
            {
                Id = 6,
                Name = "Guitar",
                Description = "Description 6",
                IsDeleted = false,
                ImageUrl = "/Instruments/Guitar.jpg",
                Type = InstrumentType.Guitar
            }
        };
    }
}