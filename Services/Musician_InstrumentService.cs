using Musicana.Api.Models;
using Musicana.Api.Repositories;
using Musicana.Api.Requests;

namespace Musicana.Api.Services;

public class Musician_InstrumentService : IMusician_InstrumentService
{
    private readonly IMusicianRepo _musicianRepo;
    private readonly I_InstrumentRepo _instrumentRepo;
    private readonly IMusicianInstrumentRepo _musician_InstrumentRepo;

    public Musician_InstrumentService(IMusicianRepo musicianRepo, I_InstrumentRepo instrumentRepo,
    IMusicianInstrumentRepo musician_InstrumentRepo)
    {
        _musicianRepo = musicianRepo;
        _instrumentRepo = instrumentRepo;
        _musician_InstrumentRepo = musician_InstrumentRepo;
    }

    public async Task AssignInstrumentToMusicianAsync(AssignInstrumentDto dto)
    {
        var musician = await _musicianRepo.GetMusicianByIdAsync(dto.MusicianId);
        if (musician is null)
            throw new Exception("Musician not found");

        var instrument = await _instrumentRepo.GetInstrumentByIdAsync(dto.InstrumentId);
        if (instrument is null)
            throw new Exception("Instrument not found");

        var alreadyAssigned = musician.musician_Instruments
            .Any(mi => mi.InstrumentId == dto.InstrumentId);

        if (alreadyAssigned)
            throw new Exception("Instrument already assigned to this musician");

        var musicianInstrument = new Musician_Instrument
        {
            MusicianId = dto.MusicianId,
            InstrumentId = dto.InstrumentId
        };

        await _musician_InstrumentRepo.AddMusicianInstrumentAsync(musicianInstrument);
        await _musician_InstrumentRepo.SaveChanges();
    }

    public async Task SaveChanges() => await _musician_InstrumentRepo.SaveChanges();
}