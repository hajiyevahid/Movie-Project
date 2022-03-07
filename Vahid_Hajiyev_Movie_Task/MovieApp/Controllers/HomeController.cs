using Microsoft.AspNetCore.Mvc;
//using MovieApp.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private CustomMovGen Model;


        public HomeController(DbContextOptions<MovieDbContext> context)
        {
            Model = new CustomMovGen( new MovieDbContext(context));
        }

        // GET: Employee
        [HttpGet]
        public ActionResult Index()
            {
                var model = Model.GetAllMG();
                ViewBag.title = "Movies List";
                ViewBag.con = model.Count();
                return View();
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }




}