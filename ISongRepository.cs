using SongFinder.Models;

namespace SongFinder
{
    public interface ISongRepository
    {
        public IEnumerable<Song> GetAllSongs();
        public Song GetSong(int id);
    }
}
