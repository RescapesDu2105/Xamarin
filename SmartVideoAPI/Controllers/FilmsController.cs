using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartVideoAPI.Controllers
{
    [Route("api/films")]
    public class FilmsController : Controller
    {
        private readonly DataAccessLayerDBFilm.DAL dal = DataAccessLayerDBFilm.DAL.Singleton("(localdb)\\MSSQLLocalDB", "FilmDB");

        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult GetAllFilms([FromBody] List<DTOLib.FilmDTO> films)
        {
            if (films == null)
            {
                return BadRequest();
            }
            
            return CreatedAtRoute("GetAllFilms", films);
        }
        */

        [HttpGet(Name = "GetAllFilms")]
        public IActionResult GetAllFilms()
        {
            List<DTOLib.FilmDTO> Films = dal.GetAllFilms();

            return new ObjectResult(Films);
        }
        /*
        [HttpPost]
        public IActionResult GetByFilms([FromBody] String nomFilm)
        {
            if (nomFilm == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetByFilms", nomFilm);
        }*/

        [HttpGet("{nomFilm}", Name = "GetByFilms")]
        public IActionResult GetByFilms(String nomFilm)
        {
            DTOLib.FilmDTO film = dal.GetFilmByName(nomFilm);
            if (film == null)
            {
                return NotFound();
            }
            return new ObjectResult(film);
        }
    }
}