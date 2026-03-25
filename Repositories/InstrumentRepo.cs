using Musicana.Api.Models;
using Microsoft.EntityFrameworkCore;
using Musicana.Api.Data;
using Musicana.Api.Enums;

namespace Musicana.Api.Repositories;

public class InstrumentRepo : I_InstrumentRepo
{
    private readonly MusicanaDbContext _context;
    public InstrumentRepo(MusicanaDbContext context)
    {
        _context = context;
    }

    public async Task CreateInstrumentAsync(Instrument instrument)
        => await _context.Instruments.AddAsync(instrument);

    public async Task<IEnumerable<Instrument>> GetAllInstrumentsAsync()
        => await _context.Instruments.ToListAsync();

    public async Task<Instrument?> GetInstrumentByIdAsync(int id)
        => await _context.Instruments.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<IEnumerable<Instrument>> GetInstrumentByNameAsync(string name)
        => await _context.Instruments
            .Where(i => i.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            
    public async Task<IEnumerable<Instrument>> GetInstrumentByTypeAsync(InstrumentType type)
        => await _context.Instruments
            .Where(i => i.Type == type).ToListAsync();


    public async Task<bool> InstrumentExistsAsync(int id) => await _context.Instruments.AnyAsync(i => i.Id == id);

    public async Task SaveChanges() => await _context.SaveChangesAsync();
}