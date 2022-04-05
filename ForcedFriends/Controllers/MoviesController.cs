using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForcedFriends.Models;



namespace ForcedFriends.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            var allMovies = Movie.GetMovies(EnvironmentVariables.ApiKey);
            return View(allMovies);
        }


    }
}
