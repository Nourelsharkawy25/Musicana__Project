using Microsoft.EntityFrameworkCore;
using Musicana.Api.Data;
using Musicana.Api.Models;
using Musicana.Api.Responses;

namespace Musicana.Api.Repositories;

public class MusicianRepo : IMusicianRepo
{
    private readonly MusicanaDbContext _context;
    public MusicianRepo(MusicanaDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Musician>> GetAllMusiciansAsync()
    {
        return await GetMusiciansWithIncludes().ToListAsync();
    }

    public async Task AddMusicianAsync(Musician musician)
    {
        await _context.Musicians.AddAsync(musician);
    }

    public async Task<Musician?> GetMusicianByIdAsync(int id)
    {
        return await GetMusiciansWithIncludes().FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Musician>> GetMusicianByNameAsync(string name)
    {
        return await GetMusiciansWithIncludes()
            .Where(m => m.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
    }

    public async Task<bool> MusicianExistsAsync(int id) =>
        await _context.Musicians.AnyAsync(m => m.Id == id);

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private IQueryable<Musician> GetMusiciansWithIncludes()
    {
        return _context.Musicians
            .Include(m => m.musician_Songs)
                .ThenInclude(ms => ms.Song)
            .Include(m => m.musician_Instruments)
                .ThenInclude(mi => mi.Instrument);
    }

}