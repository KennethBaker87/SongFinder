using SongFinder.Models;

namespace SongFinder
{
    public interface ISongRepository
    {
        public IEnumerable<Song> GetAllSongs();
        public Song GetSong(int id);
        public IEnumerable<Song> GetAllArtist(int id);
        public IEnumerable<Song> GetAllAlbums(int id);




    }

}
