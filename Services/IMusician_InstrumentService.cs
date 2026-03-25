using Musicana.Api.Requests;

namespace Musicana.Api.Services;

public interface IMusician_InstrumentService
{
    Task AssignInstrumentToMusicianAsync(AssignInstrumentDto dto);
    Task SaveChanges();
}