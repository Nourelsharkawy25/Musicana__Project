using Musicana.Api.Enums;
using Musicana.Api.Models;
using Musicana.Api.Repositories;
using Musicana.Api.Requests;
using Musicana.Api.Responses;

namespace Musicana.Api.Services;

public class SongService : ISongService
{
    private readonly ISongRepo _songRepo;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SongService(ISongRepo songRepo, IHttpContextAccessor httpContextAccessor)
    {
        _songRepo = songRepo;
        _httpContextAccessor = httpContextAccessor;
    }
    private HttpRequest Request => _httpContextAccessor.HttpContext!.Request;

    public async Task CreateSongAsync(CreateSongDto dto)
    {
        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        var song = new Song
        {
            Title = dto.Title,
            Genre = dto.Genre,
            Description = dto.Description,
            Duration = dto.Duration,
            FilePath = await SaveAudioFileAsync(dto.formFile),
            IsDeleted = false,
        };

        await _songRepo.AddSongAsync(song);
        await _songRepo.SaveChanges();

    }

    public async Task DeleteSongAsync(int songId)
    {
        if (songId <= 0)
            throw new ArgumentException("Invalid Id");

        var song = await _songRepo.GetSongByIdAsync(songId);

        if (song is null)
            throw new ArgumentNullException(nameof(song));

        song.IsDeleted = true;
        await _songRepo.SaveChanges();
    }

    public async Task<IEnumerable<SongResponse>> GetSongsAsync()
    {
        var songs = await _songRepo.GetSongsAsync();

        return SongResponse.FromModels(songs, Request);
    }

    public async Task<SongResponse?> GetSongByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid id");

        var song = await _songRepo.GetSongByIdAsync(id);

        if (song is null)
            throw new Exception("Song not found");

        return SongResponse.FromModel(song, Request);
    }

    public async Task<IEnumerable<SongResponse>> GetSongsByGenreAsync(SongGenres genre)
    {
        if (!Enum.IsDefined(typeof(SongGenres), genre))
            throw new ArgumentException("Invalid genre");

        var songs = await _songRepo.GetSongsByGenreAsync(genre);

        return SongResponse.FromModels(songs, Request);
    }

    public async Task<IEnumerable<SongResponse>> GetSongsByTitleAsync(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Genre is required");

        var songs = await _songRepo.GetSongByTitleAsync(title);

        return SongResponse.FromModels(songs, Request);
    }

    public async Task<bool> SongExistsAsync(int id)
    {
        return await _songRepo.SongExistsAsync(id);
    }

    public async Task UpdateSongAsync(int id, EditSongDto dto)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid Id");

        var song = await _songRepo.GetSongByIdAsync(id);
        if (song is null)
            throw new Exception("Song not found");

        if (dto.FormFile is not null)
        {
            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                song.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (System.IO.File.Exists(oldFilePath))
                System.IO.File.Delete(oldFilePath);

            song.FilePath = await SaveAudioFileAsync(dto.FormFile);
        }

        song.Title = dto.Title;
        song.Description = dto.Description;
        song.Duration = dto.Duration ?? song.Duration;
        song.Genre = dto.Genre;

        await _songRepo.SaveChanges();
    }

    private async Task<string> SaveAudioFileAsync(IFormFile file)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Songs");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/Songs/{uniqueFileName}";
    }

}