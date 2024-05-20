using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        // Simulación de base de datos en memoria
        private static readonly List<Movie> _movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "La noche del terror", Genre = "Terror", Price = 1, ReleaseDate = DateTime.Now },
            new Movie { Id = 2, Title = "La comedia del año", Genre = "Comedia", Price = 2, ReleaseDate = DateTime.Now }
        };

        // GET: MoviesController
        public ActionResult Index()
        {
            return View(_movies);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                movie.Id = _movies.Max(m => m.Id) + 1;
                _movies.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                var existingMovie = _movies.FirstOrDefault(m => m.Id == id);
                if (existingMovie == null)
                {
                    return NotFound();
                }
                existingMovie.Title = movie.Title;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Genre = movie.Genre;
                existingMovie.Price = movie.Price;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var movie = _movies.FirstOrDefault(m => m.Id == id);
                if (movie == null)
                {
                    return NotFound();
                }
                _movies.Remove(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


