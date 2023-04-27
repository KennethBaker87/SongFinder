using Microsoft.AspNetCore.Mvc;
using SongFinder.Models;
using System.Linq;



namespace SongFinder.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongRepository repo;
        public SongController(ISongRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index(string searchText = "")
        {
            
            if (searchText != "" && searchText != null)
            {
                
                var songs = repo.GetAllSongs()
                    .Where(p => p.SongName.ToLower().Contains(searchText.ToLower()));
                
                return View(songs); 
               
            }
            else
            {
                var songs = repo.GetAllSongs();
                return View(songs);
            }

            

        }
        public IActionResult ViewSong(int id)
        {

            var song = repo.GetSong(id);
            return View(song);
        }
        public IActionResult ViewArtist(int id)
        {
            var song = repo.GetArtist(id);
            return View(song);
        }
        public IActionResult ViewAlbum(int id)
        {
            var song = repo.GetAlbums(id);
            return View(song);
        }
        public IActionResult ViewAllArtist()
        {
            var song = repo.GetAllArtist();
            return View(song);
        }
        public IActionResult ViewAllAlbum()
        {
            var song = repo.GetAllAlbum();
            return View(song);
        }
        public IActionResult ViewArtistButton(int id)
        {
            var song = repo.GetArtistButton(id);
            return View(song);
        }

        public IActionResult ViewSimilarSongs(int id)
        {
            var song = repo.GetSimilarSongs(id);
            return View(song);
        }
        public IActionResult UpdateSong(int id)
        {
            Song song = repo.GetSong(id);
            if (song == null)
            {
                return View("SongNotFound");
            }
            return View(song);
        }
        public IActionResult UpdateSongToDatabase(Song song)
        {
            repo.UpdateSong(song);

            return RedirectToAction("ViewSong", new { id = song.ID });
        }
        public IActionResult InsertSong()
        {
            var song = repo.AssignSongInfo();
            return View(song);
        }
        public IActionResult InsertSongToDatabase(Song songToInsert)
        {
            repo.InsertSong(songToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSong(Song song)
        {
            repo.DeleteSong(song);
            return RedirectToAction("Index");
        }
    }
}
