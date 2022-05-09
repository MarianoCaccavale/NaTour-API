using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;
using NaTour2021_API.Extensions;
using NaTour2021_API.DBHelper;

namespace NaTour2021_API.Repositories.Track
{
    /// <summary>
    /// Classe <c>PostgreTrackRepository</c> implementazione dell'interfaccia TrackRepository che mette a disposizioni le 
    /// principali operazioni eseguibili sulla base dati PostgreSQL
    /// </summary>
    public class PostgreTrackRepository : ITrackRepository
    {

        private readonly PostgreSqlHelper db;

        //Creazione del DBHelper con dependency injection. Sarebbe più efficace con un helper interfaccia, da considerare
        public PostgreTrackRepository(PostgreSqlHelper db)
        {
            this.db = db;
        }

        /// <summary>
        /// Metodo per l'inserimento dei tracciati. Parametro di input <paramref name="trackInfo"/>, trackDTO a cui verrà 
        /// aggiunto il Guid e la data di creazione, prima di salvare il tutto in PostgreSQL
        /// </summary>
        /// <param name="trackInfo"></param>
        public void AddTrack(TrackDTO trackInfo)
        {
            TrackModel trackModel = trackInfo.FromDTO();
            db.tracks.Add(trackModel);
            db.SaveChanges();
        }

        /// <summary>
        /// Metodo che restituisce gli ultimi 15 tracciati inseriti in piattaforma, restituendoli dalla base di dati PostgreSQL
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TrackModel> GetRecentTracks()
        {
            return db.tracks.OrderBy(track => track.creationDate).Take(15).ToList();
        }

        /// <summary>
        /// Metodo che ricerca nella base di dati PostgreSQL il tracciato con nome <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TrackModel GetTrackByName(string name)
        {
            return db.tracks.Where(track => track.Name == name).ToList().First();
        }

        /// <summary>
        /// Metodo che ricerca nella base di dati PostgreSQL il tracciato con Guid <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TrackModel ITrackRepository.GetById(Guid id)
        {
            return db.tracks.Where(track => track.Id == id).ToList().First();
        }
    }
}
