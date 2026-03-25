using Musicana.Api.Enums;
using Musicana.Api.Models;

namespace Musicana.Api.Repositories;

public interface I_InstrumentRepo
{
    Task<Instrument> GetInstrumentByIdAsync(int id);
    Task<IEnumerable<Instrument>> GetAllInstrumentsAsync();
    Task<IEnumerable<Instrument>> GetInstrumentByNameAsync(string name);
    Task<IEnumerable<Instrument>> GetInstrumentByTypeAsync(InstrumentType type);
    Task<bool> InstrumentExistsAsync(int id);
    Task SaveChanges();
    Task CreateInstrumentAsync(Instrument instrument);

}