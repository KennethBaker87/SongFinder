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
            return _conn.Query<Song>("select distinct album, ReleaseDate, albumid, artistid, AlbumArt from songinfo WHERE Artistid = @id", new { id });
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
        public IEnumerable<Song> GetSimilarSongs(int id)
        {
            return _conn.Query<Song>("select * from songfinder.compareinfo where ChordProgressionID = @id", new { id });
        }
        public void UpdateSong(Song song)
        {
            _conn.Execute("UPDATE songinfo SET SongName = @SongName, Artist = @Artist, Album = @Album, ReleaseDate = @ReleaseDate," +
                "TrackNumber = @TrackNumber, Producer = @Producer WHERE ID = @id",
             new { SongName = song.SongName, Artist = song.Artist, Album = song.Album, ReleaseDate = song.ReleaseDate, 
                 TrackNumber = song.TrackNumber, Producer = song.Producer, id = song.ID });
        }
        public void InsertSong(Song songToInsert)
        {
            _conn.Execute("INSERT INTO songinfo (SongName, Artist, ID) VALUES (@SongName, @Artist, @ID);",
                new { SongName = songToInsert.SongName, Artist = songToInsert.Artist, ID = songToInsert.ID });
        }
        public IEnumerable<Category> GetSongInfo()
        {
            return _conn.Query<Category>("SELECT * FROM SongInfo;");
        }
        public Song AssignSongInfo()
        {
            var songInfoList = GetSongInfo();
            var song = new Song();
            song.Categories = songInfoList;
            return song;
        }
        public void DeleteSong(Song song)
        {
            _conn.Execute("DELETE FROM songinfo WHERE ID = @id;", new { id = song.ID });
            
        }
    }
}
