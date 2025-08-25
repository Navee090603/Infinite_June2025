using Code_Challenge_9_Question_2_.Models;
using Code_Challenge_9_Question_2_.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_Challenge_9_Question_2_.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepo<Movie> _repo = null;

        public MoviesController()
        {
            _repo = new MovieRepo<Movie>();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _repo.GetAll();
            return View(movies);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(m);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var movie = _repo.GetByID(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(m);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            var movie = _repo.GetByID(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }

        // GET: ByYear 
        public ActionResult ByYear()
        {
            return View((IEnumerable<Movie>)null);
        }

        // POST: ByYear
        [HttpPost]
        public ActionResult ByYear(int year)
        {
            var movies = _repo.GetByYear(year);
            ViewBag.Year = year;
            return View(movies);
        }

        // GET: ByDirector 
        public ActionResult ByDirector()
        {
            return View((IEnumerable<Movie>)null);
        }

        // POST: ByDirector 
        [HttpPost]
        public ActionResult ByDirector(string director)
        {
            var movies = _repo.GetByDirector(director);
            ViewBag.Director = director;
            return View(movies);
        }
    }
}