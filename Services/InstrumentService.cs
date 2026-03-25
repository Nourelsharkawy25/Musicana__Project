using Musicana.Api.Enums;
using Musicana.Api.Models;
using Musicana.Api.Repositories;
using Musicana.Api.Requests;
using Musicana.Api.Responses;

namespace Musicana.Api.Services;

public class InstrumentService : I_InstrumentService
{
    private readonly I_InstrumentRepo _instrumentRepo;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public InstrumentService(I_InstrumentRepo instrumentRepo, IHttpContextAccessor httpContextAccessor)
    {
        _instrumentRepo = instrumentRepo;
        _httpContextAccessor = httpContextAccessor;
    }

    private HttpRequest Request => _httpContextAccessor.HttpContext!.Request;

    public async Task<IEnumerable<InstrumentResponse>> GetAllInstrumentsAsync()
    {
        var instruments = await _instrumentRepo.GetAllInstrumentsAsync();
        return InstrumentResponse.FromModels(instruments, Request);
    }

    public async Task<InstrumentResponse> GetInstrumentByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");

        var instrument = await _instrumentRepo.GetInstrumentByIdAsync(id);

        if (instrument is null)
            throw new Exception("Instrument not found");

        return InstrumentResponse.FromModel(instrument, Request);
    }

    public async Task<IEnumerable<InstrumentResponse>> GetInstrumentsByTypeAsync(InstrumentType type)
    {
        if (!Enum.IsDefined(typeof(InstrumentType), type))
            throw new ArgumentException("Invalid instrument type");

        var instruments = await _instrumentRepo.GetInstrumentByTypeAsync(type);
        return InstrumentResponse.FromModels(instruments, Request);
    }

    public async Task<IEnumerable<InstrumentResponse>> GetInstrumentsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is invalid", nameof(name));

        var instruments = await _instrumentRepo.GetInstrumentByNameAsync(name);
        return InstrumentResponse.FromModels(instruments, Request);
    }

    public async Task<bool> InstrumentExistsAsync(int id)
        => await _instrumentRepo.InstrumentExistsAsync(id);

    public async Task CreateInstrumentAsync(CreateInstrumentDto instrumentDto)
    {
        if (instrumentDto is null)
            throw new ArgumentNullException(nameof(instrumentDto));

        var instrument = new Instrument
        {
            Name = instrumentDto.Name,
            Type = instrumentDto.Type,
            Description = instrumentDto.Description,
        };

        if (instrumentDto.ImageUrl is not null)
            instrument.ImageUrl = await SaveImageAsync(instrumentDto.ImageUrl);

        await _instrumentRepo.CreateInstrumentAsync(instrument);
        await _instrumentRepo.SaveChanges();

    }

    public async Task UpdateInstrumentAsync(int id, EditInstrumentDto instrumentDto)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");

        if (instrumentDto is null)
            throw new ArgumentNullException(nameof(instrumentDto));

        var instrument = await _instrumentRepo.GetInstrumentByIdAsync(id);

        if (instrument is null)
            throw new Exception("Instrument not found");

        instrument.Name = instrumentDto.Name;
        instrument.Type = instrumentDto.Type;
        instrument.Description = instrumentDto.Description;

        if (instrumentDto.Image is not null)
        {
            DeleteImage(instrument.ImageUrl);
            instrument.ImageUrl = await SaveImageAsync(instrumentDto.Image);
        }

        await _instrumentRepo.SaveChanges();
    }

    public async Task DeleteInstrumentAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Id is invalid");

        var instrument = await _instrumentRepo.GetInstrumentByIdAsync(id);

        if (instrument is null)
            throw new Exception("Instrument not found");

        instrument.IsDeleted = true;

        await _instrumentRepo.SaveChanges();
    }

    private async Task<string> SaveImageAsync(IFormFile image)
    {
        var uploadsFolder = Path.Combine("wwwroot", "Instruments");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await image.CopyToAsync(stream);

        return $"/Instruments/{fileName}";
    }

    private void DeleteImage(string? imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl)) return;

        var filePath = Path.Combine("wwwroot", imageUrl.TrimStart('/'));
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}