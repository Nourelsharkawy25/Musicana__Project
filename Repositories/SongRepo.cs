using Microsoft.EntityFrameworkCore;
using Musicana.Api.Data;
using Musicana.Api.Enums;
using Musicana.Api.Models;

namespace Musicana.Api.Repositories;

public class SongRepo : ISongRepo
{
    private readonly MusicanaDbContext _context;
    public SongRepo(MusicanaDbContext context) => _context = context;
    public async Task AddSongAsync(Song song)
    {
        await _context.Songs.AddAsync(song);
    }

    public async Task<Song?> GetSongByIdAsync(int songId)
    {
        return await _context.Songs.FirstOrDefaultAsync(s => s.Id == songId);
    }

    public async Task<IEnumerable<Song>> GetSongByTitleAsync(string title)
    {
        return await _context.Songs.
            Where(s => s.Title.ToLower().Contains(title.ToLower()))
            .ToListAsync();
    }

    public async Task<IEnumerable<Song>> GetSongsAsync()
    {
        return await _context.Songs.ToListAsync();
    }

    public async Task<IEnumerable<Song>> GetSongsByGenreAsync(SongGenres genre)
    {
        return await _context.Songs
            .Where(s => s.Genre == genre).ToListAsync();
    }
    public async Task SaveChanges() => await _context.SaveChangesAsync();
    public async Task<bool> SongExistsAsync(int id) => await _context.Songs.AnyAsync(s => s.Id == id);
}