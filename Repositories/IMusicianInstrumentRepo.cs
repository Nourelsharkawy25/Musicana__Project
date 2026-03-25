using Musicana.Api.Models;
using Musicana.Api.Requests;

namespace Musicana.Api.Repositories;

public interface IMusicianInstrumentRepo
{
    Task AddMusicianInstrumentAsync(Musician_Instrument musicianInstrument);
    Task SaveChanges();
}