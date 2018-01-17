using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DTOLib;
using Microsoft.AspNetCore.Mvc;

namespace SmartVideoAPI.Controllers
{
    public class FilmsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<FilmDTO> GetAllFilms()
        {
            return BLLFilm.getAllFilms();
        }

        [HttpGet]
        public List<FilmDTO> Actors(int id)
        {
            return null;// BLLFilm.getStock();
        }
    }
}