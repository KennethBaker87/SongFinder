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


    }

}
