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

        public IEnumerable<Song> GetArtist(int id)
        {
            return _conn.Query<Song>("select distinct album, ReleaseDate, artistid, AlbumArt from songinfo WHERE id = @id", new { id });
        }
        public IEnumerable<Song> GetAlbums(int id)
        {
            return _conn.Query<Song>("select * from songinfo where AlbumID = @id Order by TrackNumber", new { id });
        }
        public IEnumerable<Song> GetAllArtist()
        {
            return _conn.Query<Song>("Select distinct artist, artistid from songinfo Order By Artist ASC");
        }
        public IEnumerable<Song> GetAllAlbum()
        {
            return _conn.Query<Song>("Select distinct album, artist, artistid, AlbumID from songinfo Order By Artist ASC");
        }
        public IEnumerable<Song> GetArtistButton(int id)
        {
            return _conn.Query<Song>("select distinct album, ReleaseDate, artistid, AlbumArt from songinfo WHERE artistid = @id", new { id });
        }
    }
}
