using Musicana.Api.Data;
using Musicana.Api.Models;
using Musicana.Api.Requests;

namespace Musicana.Api.Repositories;

public class MusicianInstrumentRepo : IMusicianInstrumentRepo
{
    private readonly MusicanaDbContext _context;
    public MusicianInstrumentRepo(MusicanaDbContext context)
    {
        _context = context;
    }

    public async Task AddMusicianInstrumentAsync(Musician_Instrument musician_Instrument)
    {
        await _context.Musician_Instruments.AddAsync(musician_Instrument);
    }

    public async Task SaveChanges() => await _context.SaveChangesAsync();
}