using Musicana.Api.Models;
using Musicana.Api.Repositories;
using Musicana.Api.Requests;
using Musicana.Api.Responses;

namespace Musicana.Api.Services;

public class MusicianService : IMusicianService
{
    private readonly IMusicianRepo _musicianRepo;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MusicianService(IMusicianRepo musicianRepo, IHttpContextAccessor httpContextAccessor)
    {
        _musicianRepo = musicianRepo;
        _httpContextAccessor = httpContextAccessor;
    }

    private HttpRequest Request => _httpContextAccessor.HttpContext!.Request;

    public async Task<IEnumerable<MusicianResponse>> GetAllMusiciansAsync()
    {
        var musicians = await _musicianRepo.GetAllMusiciansAsync();
        return MusicianResponse.FromMusicians(musicians, Request);
    }

    public async Task<MusicianResponse> GetMusicianByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");

        var musician = await _musicianRepo.GetMusicianByIdAsync(id);

        if (musician is null)
            throw new Exception("Musician not found");

        return MusicianResponse.FromMusician(
            musician,
            Request,
            musician.musician_Songs?.Select(ms => ms.Song),
            musician.musician_Instruments?.Select(mi => InstrumentResponse.FromModel(mi.Instrument, Request))
        );
    }

    public async Task<IEnumerable<MusicianResponse>> GetMusicianByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is invalid", nameof(name));

        var musicians = await _musicianRepo.GetMusicianByNameAsync(name);
        return MusicianResponse.FromMusicians(musicians, Request);
    }

    public async Task CreateMusicianAsync(CreateMusicianDto musicianDto)
    {
        if (musicianDto is null)
            throw new ArgumentNullException(nameof(musicianDto));

        var musician = new Musician
        {
            Name = musicianDto.Name,
            BirthDate = musicianDto.BirthDate,
            Genre = musicianDto.Genre
        };

        await _musicianRepo.AddMusicianAsync(musician);
        await _musicianRepo.SaveAsync();
    }

    public async Task UpdateMusicianAsync(int id, EditMusicianDto musicianDto)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");

        if (musicianDto is null)
            throw new ArgumentNullException(nameof(musicianDto));

        var musician = await _musicianRepo.GetMusicianByIdAsync(id);

        if (musician is null)
            throw new Exception("Musician not found");

        musician.Name = musicianDto.Name;
        musician.BirthDate = musicianDto.BirthDate;
        musician.Genre = musicianDto.Genre;

        await _musicianRepo.SaveAsync();
    }

    public async Task DeleteMusicianAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");

        var musician = await _musicianRepo.GetMusicianByIdAsync(id);

        if (musician is null)
            throw new Exception("Musician not found");

        var relatedSongs = musician.musician_Songs
            .Where(ms => ms.Song.musician_Songs.Count == 1)
            .Select(ms => ms.Song)
            .ToList();

        foreach (var song in relatedSongs)
            song.IsDeleted = true;

        musician.IsDeleted = true;

        await _musicianRepo.SaveAsync();
    }

    public async Task<bool> MusicianExistsAsync(int id)
        => await _musicianRepo.MusicianExistsAsync(id);
}