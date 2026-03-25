using Musicana.Api.Data;
using Musicana.Api.Models;

namespace Musicana.Api.Repositories;

public class MusicianSongRepo : IMusicianSongRepo
{
    private readonly MusicanaDbContext _context;
    public MusicianSongRepo(MusicanaDbContext context) => _context = context;
    public async Task AddSongToMusicianAsync(Musician_Song musician_Song) =>
        await _context.Musician_Songs.AddAsync(musician_Song);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}