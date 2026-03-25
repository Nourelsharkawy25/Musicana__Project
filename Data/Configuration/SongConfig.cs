using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicana.Api.Enums;
using Musicana.Api.Models;

namespace Musicana.Api.Data.Configuration;

public class SongConfig : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Songs");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title).HasMaxLength(60).IsRequired();
        builder.Property(s => s.Description).HasMaxLength(100);
        builder.Property(s => s.Genre).HasMaxLength(30).IsRequired();
        builder.Property(s => s.FilePath).IsRequired();
        builder.Property(s => s.IsDeleted).IsRequired();

        builder.HasData(LoadData());
    }

    private List<Song> LoadData()
    {
        return new List<Song>
        {
            new Song()
            {
                Id = 1,
                Title = "Song 1",
                Description = "Description 1",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Rock
            },
            new Song()
            {
                Id = 2,
                Title = "Song 2",
                Description = "Description 2",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Pop
            },
            new Song()
            {
                Id = 3,
                Title = "Song 3",
                Description = "Description 3",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Jazz
            },
            new Song()
            {
                Id = 4,
                Title = "Song 4",
                Description = "Description 4",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Classical
            },
            new Song()
            {
                Id = 5,
                Title = "Song 5",
                Description = "Description 5",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Country
            },
            new Song()
            {
                Id = 6,
                Title = "Song 6",
                Description = "Description 6",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Rock
            },
            new Song()
            {
                Id = 7,
                Title = "Song 7",
                Description = "Description 7",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Classical
            },
            new Song()
            {
                Id = 8,
                Title = "Song 8",
                Description = "Description 8",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.HipHop
            },
            new Song()
            {
                Id = 9,
                Title = "Song 9",
                Description = "Description 9",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Metal
            },
            new Song()
            {
                Id = 10,
                Title = "Song 10",
                Description = "Description 10",
                FilePath = "/Songs/song1.mp3",
                IsDeleted = false,
                Genre = SongGenres.Rock
            }
        };
    }
}