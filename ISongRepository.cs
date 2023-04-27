using SongFinder.Models;

namespace SongFinder
{
    public interface ISongRepository
    {
        public IEnumerable<Song> GetAllSongs();
        public Song GetSong(int id);
        public IEnumerable<Song> GetArtist(int id);
        public IEnumerable<Song> GetAlbums(int id);
        public IEnumerable<Song> GetAllArtist();
        public IEnumerable<Song> GetAllAlbum();
        public IEnumerable<Song> GetArtistButton(int id);
        public IEnumerable<Song> GetSimilarSongs(int id);
        public void UpdateSong(Song song);
        public void InsertSong(Song songToInsert);
        public IEnumerable<Category> GetSongInfo();
        public Song AssignSongInfo();
        public void DeleteSong(Song song);
    }

}
