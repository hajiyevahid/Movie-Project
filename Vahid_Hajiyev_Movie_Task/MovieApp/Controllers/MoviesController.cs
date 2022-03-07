using Microsoft.AspNetCore.Mvc;
//using MovieApp.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApp.Services;
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private CustomMovGen Model;


        public MoviesController(DbContextOptions<MovieDbContext> context)
        {
            Model = new CustomMovGen(new MovieDbContext(context));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = Model.GetAllMG();
            ViewBag.title = "Movies List";
            ViewBag.con = model.Count();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = Model.GetMovieById(id);
            ViewBag.title = "Detailed View";
            var mod = Model.GetAllMG();
            ViewBag.con = mod.Count();
            return View(model);
        }

        [Route("/Movies/Delete/{id}")]
        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            var model = Model.DeleteMovie(id);
            ViewBag.model = model;
            return RedirectToAction("Index");
//            return Ok();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.title = "Movie Creator";
            var mod = Model.GetAllMG();
            ViewBag.con = mod.Count();
            List<Genre> gens = Model.GetAllGenres();
            ViewBag.gens = gens;
            return View();
        }
        //string Title, string ReleaseDate, string LongDescription, string Genre
        [HttpPost]
        public ActionResult Create(int GenreId, string Title, string ReleaseDate, string LongDescription, string Director, string MainCast)
        {
            Movie movie = new Movie();
            movie.Title = Title;
            movie.MainCast = MainCast;
            movie.Director = Director;
            movie.GenreId = GenreId;
            movie.ReleaseDate = DateOnly.ParseExact(ReleaseDate, "yyyy-MM-dd");
            movie.LongDescription = LongDescription;
            //            Model.DeleteMovie(Id);
            Model.AddMovie(movie);
            return RedirectToAction("Index");
            //            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.title = "Error";
            return View();
        }
        //Movies/Editd/2&Id=2&GenreId=1&Title=VahidTitle&ReleaseDate=2000-11-11
        //    LongDescription=Sasas+a+a+sas+a+a+a+a+asdf+sdf+sdf+sdf+&Director=HajiyevDirector&MainCast=WinstonCast&Genre=Western
        [HttpPost]
        public ActionResult Edit(int Id, int GenreId, string Title, string ReleaseDate, string LongDescription, string Director, string MainCast)
        {
            Movie movie = new Movie();
            movie.Id = Id;
            movie.Title = Title;
            movie.MainCast = MainCast;
            movie.Director = Director;
            movie.GenreId = GenreId;
            movie.ReleaseDate = DateOnly.ParseExact(ReleaseDate,"yyyy-MM-dd");
            movie.LongDescription = LongDescription;
//            Model.DeleteMovie(Id);
            Model.EditMovie(movie);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var mod = Model.GetAllMG();
            ViewBag.con = mod.Count();
            ViewBag.title = "Movie Editor";
            var model = Model.GetMovieById(id);
            List<Genre> gens = Model.GetAllGenres();
            ViewBag.gens = gens;
            return View(model);
        }

 
    }




}