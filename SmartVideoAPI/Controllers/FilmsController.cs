using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartVideoAPI.Controllers
{
    public class FilmsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public List<DTOLib.FilmDTO> GetAllFilms()
        {
            return BLLFilm.getAllFilms();
        }

        [HttpGet]
        public List<DTOLib.FilmDTO> Actors(int id)
        {
            return BLLFilm.
        }
    }
}
