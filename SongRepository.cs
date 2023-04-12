using Dapper;
using System.Collections.Generic;
using SongFinder.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace SongFinder
{
    public class SongRepository :ISongRepository
    {
        private readonly IDbConnection _conn;

        public SongRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return _conn.Query<Song>("Select * From songinfo Order By Artist ASC");
        }
        public Song GetSong(int id)
        {
            return _conn.QuerySingle<Song>("SELECT * FROM songinfo WHERE ID = @id", new { id });
        }

        public IEnumerable<Song> GetAllArtist(int id)
        {
            return _conn.Query<Song>("select distinct album, ReleaseDate, AlbumArt from songinfo WHERE ID = @id", new { id });
        }
        public IEnumerable<Song> GetAllAlbums(int id)
        {
            return _conn.Query<Song>("select * from songinfo where AlbumID = @id Order by TrackNumber", new { id });
        }
    }
}
