using Musicana.Api.Enums;
using Musicana.Api.Models;

namespace Musicana.Api.Responses;

public class InstrumentResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public InstrumentType Type { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    private InstrumentResponse() { }

    public static InstrumentResponse FromModel(Instrument instrument, HttpRequest request)
    {
        if (instrument is null)
            throw new Exception(nameof(instrument));

        return new InstrumentResponse
        {
            Id = instrument.Id,
            Name = instrument.Name,
            Type = instrument.Type,
            Description = instrument.Description,
            ImageUrl = instrument.ImageUrl != null
                ? $"{request.Scheme}://{request.Host}{instrument.ImageUrl}"
                : null
        };
    }

    public static IEnumerable<InstrumentResponse> FromModels(IEnumerable<Instrument> instruments, HttpRequest request)
    {
        if (instruments is null)
            throw new ArgumentNullException(nameof(instruments));

        return instruments.Select(i => FromModel(i, request));
    }
}