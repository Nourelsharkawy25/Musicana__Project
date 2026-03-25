using Musicana.Api.Enums;
using Musicana.Api.Requests;
using Musicana.Api.Responses;

namespace Musicana.Api.Services;

public interface I_InstrumentService
{
    Task<IEnumerable<InstrumentResponse>> GetAllInstrumentsAsync();
    Task<InstrumentResponse> GetInstrumentByIdAsync(int id);
    Task<IEnumerable<InstrumentResponse>> GetInstrumentsByTypeAsync(InstrumentType type);
    Task<IEnumerable<InstrumentResponse>> GetInstrumentsByNameAsync(string name);
    Task<bool> InstrumentExistsAsync(int id);
    Task DeleteInstrumentAsync(int id);
    Task UpdateInstrumentAsync(int id, EditInstrumentDto instrumentDto);
    Task CreateInstrumentAsync(CreateInstrumentDto instrumentDto);

}