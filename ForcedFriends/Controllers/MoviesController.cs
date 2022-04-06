using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForcedFriends.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;



namespace ForcedFriends.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ForcedFriendsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public MoviesController(UserManager<ApplicationUser> userManager,ForcedFriendsContext db)
        {
          _userManager = userManager;
          _db = db;
        } 
        public IActionResult Index()
        {
            var allMovies = Movie.GetMovies(EnvironmentVariables.apiKey);
            return View(allMovies);
        }

        public async Task <ActionResult> Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            ViewBag.ApplicationUser = currentUser;
            var thisMovie = Movie.GetMovie(EnvironmentVariables.apiKey, id);
            return View(thisMovie);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddMovie(Movie movie, string Id)
        {
          var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          var currentUser = await _userManager.FindByIdAsync(userId);
          _db.ApplicationUserMovies.Add(new ApplicationUserMovie() {ApplicationUserId = Id, Id = movie.Id });
          // Console.Write("ApplicationUserId : " +ApplicationUserId);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
    }
}
