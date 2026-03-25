using Musicana.Api.Enums;
using Musicana.Api.Models;
using Musicana.Api.Responses;

public class MusicianResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MusicianGenre? Genre { get; set; }
    public DateTime BirthDate { get; set; }
    public List<SongResponse> Songs { get; set; } = new List<SongResponse>();
    public List<InstrumentResponse> Instruments { get; set; } = new List<InstrumentResponse>();

    private MusicianResponse() { }

    public static MusicianResponse FromMusician(Musician musician,
        HttpRequest request,
        IEnumerable<Song>? songs = null,
        IEnumerable<InstrumentResponse>? instrumentResponses = null)
    {
        if (musician is null)
            throw new ArgumentNullException(nameof(musician));

        var response = new MusicianResponse
        {
            Id = musician.Id,
            Name = musician.Name,
            Genre = musician.Genre,
            BirthDate = musician.BirthDate
        };

        if (songs != null)
            response.Songs = SongResponse.FromModels(songs, request).ToList();

        if (instrumentResponses != null)
            response.Instruments = instrumentResponses.ToList();

        return response;
    }

    public static IEnumerable<MusicianResponse> FromMusicians(IEnumerable<Musician> musicians, HttpRequest request)
    {
        if (musicians is null)
            throw new ArgumentNullException(nameof(musicians));

        return musicians.Select(m => FromMusician(
            m,
            request,
            m.musician_Songs?.Select(ms => ms.Song),
            m.musician_Instruments?.Select(mi => InstrumentResponse.FromModel(mi.Instrument, request))
        ));
    }
}