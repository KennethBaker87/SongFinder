﻿using Microsoft.AspNetCore.Mvc;
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
                    .Where(p => p.SongName.Contains(searchText));
                return View(songs);   
            }
            else
            {
                var songs = repo.GetAllSongs();
                return View(songs);
            }
            
        }
        


    }
}