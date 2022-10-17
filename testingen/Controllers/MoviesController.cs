using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testingen.Data;
using testingen.Models;
using testingen.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testingen.Controllers
{
    public class MoviesController : Controller
    {


        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET


        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movie.Add(movie);
            else
            {
                var MovieInDb = _context.Movie.Single(c => c.Id == movie.Id);

            }


            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new NewMovieViewModel { Genres = genres };
            return View(viewModel);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public ActionResult Random()
        {

            var movie = new Movie() { Name = "shrek", Id = 1 };
            var customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "customer 1"},
                new Customer{Id = 2, Name = "customer 2"},
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);

        }

        public ActionResult Edit(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;

            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/released/{year}/{{month:regex(\\d{4}):range(1,12)}}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}

