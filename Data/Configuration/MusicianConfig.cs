using Microsoft.EntityFrameworkCore;
using Musicana.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicana.Api.Enums;

namespace Musicana.Api.Data.Configuration;

public class MusicianConfig : IEntityTypeConfiguration<Musician>
{
    public void Configure(EntityTypeBuilder<Musician> builder)
    {
        builder.HasKey(m => m.Id);
        builder.ToTable("Musicians");

        builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
        builder.Property(m => m.Genre).HasMaxLength(60);
        builder.Property(m => m.BirthDate).IsRequired();
        builder.Property(m => m.IsDeleted).IsRequired();

        builder.HasData(LoadData());
    }

    private static List<Musician> LoadData()
    {
        return new List<Musician>
        {
            new Musician
            {
                Id = 1,
                Name = "John Doe",
                Genre = MusicianGenre.Classical,
                BirthDate = new DateTime(1990, 1, 1),
                IsDeleted = false
            },
            new Musician
            {
                Id = 2,
                Name = "Jane Smith",
                Genre = MusicianGenre.Romantic,
                BirthDate = new DateTime(1992, 5, 15),
                IsDeleted = false
            },
            new Musician
            {
                Id = 3,
                Name = "Bob Johnson",
                Genre = MusicianGenre.Jazz,
                BirthDate = new DateTime(1985, 10, 30),
                IsDeleted = false
            },
            new Musician
            {
                Id = 4,
                Name = "Alice Brown",
                Genre = MusicianGenre.Metal,
                BirthDate = new DateTime(1988, 3, 20),
                IsDeleted = false
            },
            new Musician
            {
                Id = 5,
                Name = "Charlie Davis",
                Genre = MusicianGenre.Sad,
                BirthDate = new DateTime(1995, 7, 10),
                IsDeleted = false
            },
            new Musician
            {
                Id = 6,
                Name = "Emily Wilson",
                Genre = MusicianGenre.Country,
                BirthDate = new DateTime(1991, 11, 5),
                IsDeleted = false
            },
            new Musician
            {
                Id = 7,
                Name = "Michael Taylor",
                Genre = MusicianGenre.Pop,
                BirthDate = new DateTime(1987, 2, 25),
                IsDeleted = false
            },
            new Musician
            {
                Id = 8,
                Name = "Sarah Miller",
                Genre = MusicianGenre.Romantic,
                BirthDate = new DateTime(1993, 9, 12),
                IsDeleted = false
            },
        };
    }
}
