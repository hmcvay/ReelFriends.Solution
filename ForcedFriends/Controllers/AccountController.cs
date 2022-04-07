using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ForcedFriends.Models;
using System.Threading.Tasks;
using ForcedFriends.ViewModels;
using System;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.Extensions.Logging;


namespace ForcedFriends.Controllers
{
  public class AccountController : Controller
  {
    private readonly ForcedFriendsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ForcedFriendsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public async Task<ActionResult> Index(string id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      return View(currentUser);
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Login");
      }
      else
      {
        return View();
      }
    }
    public ActionResult Login()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
      if(result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
    public async Task<ActionResult> Edit(string id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      return View(currentUser);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(string id, string bio, string name, DateTime birthday)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      currentUser.Bio = bio;
      currentUser.Name = name;
      currentUser.Birthday = birthday;
      IdentityResult result = await _userManager.UpdateAsync(currentUser);
      return RedirectToAction("Index");
    }

[HttpGet]
    public async Task<ActionResult> ViewMatches()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<ApplicationUser> allUsers = _userManager.Users.ToList();
      allUsers.Remove(currentUser);
      List<ApplicationUserMovie> thisUserWatchList = new List<ApplicationUserMovie>();
      List<ApplicationUserMovie> otherUserWatchList = new List<ApplicationUserMovie>();
      foreach(var individualUser in allUsers)
      {
        Console.WriteLine("++++Userid++++++++++"+individualUser.UserName);
        thisUserWatchList= _db.ApplicationUserMovies.Where(m => m.ApplicationUserId == userId).ToList();
        List<ApplicationUserMovie> movieMatchList = new List<ApplicationUserMovie>();
        if(individualUser.Id!=userId)
        {
          otherUserWatchList = _db.ApplicationUserMovies.Where(m => m.ApplicationUserId == individualUser.Id).ToList();
          foreach(ApplicationUserMovie movieX in thisUserWatchList)
          {
            foreach (ApplicationUserMovie movieY in otherUserWatchList)
            {
              if (movieX.MovieId == movieY.MovieId)
              {
                movieMatchList.Add(movieY);
              }
            }
          }
          individualUser.MatchCount = movieMatchList.Count;
        }
      }
      return View(allUsers);
    }

    // [HttpGet]
    // public ActionResult ViewMatches()
    // {
    //   // var allUsers = _userManager.Users.ToList();
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   List<ApplicationUser> allUsers = _userManager.Users.ToList();
    //   Console.WriteLine(allUsers.Count);
    //   List<ApplicationUserMovie> thisUserWatchList = new List<ApplicationUserMovie>{};
    //   List<ApplicationUserMovie> otherUserWatchList = new List<ApplicationUserMovie>{};
    //   foreach(var individualUser in allUsers)
    //   {
    //     Console.WriteLine("++++Userid++++++++++"+individualUser.UserName);
    //     Console.WriteLine("++++Userid++++++++++"+individualUser.Id);
    //     thisUserWatchList= _db.ApplicationUserMovies.Where(m => m.ApplicationUserId == userId).ToList();
    //   /* if(individualUser.Id!=userId)
    //     {
    //         otherUserWatchList = _db.ApplicationUserMovies.Where(m => m.ApplicationUserId == individualUser.Id).ToList();
    //     }
    //     For(var items in thisUserWatchList )
    //     {
    //       otherUserWatchList.contain(items);
    //       count++
    //     }
    //       display counter;
    //       push this counter in an array;
    //       eg if we have two users then the array will have two values and pick the highest of them;
    //       */
        
    //     IEnumerable<ApplicationUserMovie> Match = otherUserWatchList.Intersect(thisUserWatchList);
    //     var MatchCount = thisUserWatchList.Intersect(otherUserWatchList).Count();
    //     Console.WriteLine("-------This user watch list-----"+thisUserWatchList.Count());

    //     Console.WriteLine("-------Other user watch list-----"+otherUserWatchList.Count());

    //     //Console.WriteLine("-------Count-----"+MatchCount);
    //     Console.WriteLine("------;-match-----"+Match.Count());
    //   }

    //   return View(allUsers);
    // }
    public ActionResult Details(string id)
    {
      var thisUser = _userManager.Users
      .Include(user => user.JoinEntities)
      .ThenInclude(join => join.Movie)
      .FirstOrDefault(user => user.Id == id);
      var watchList = _db.ApplicationUserMovies.Where(m => m.ApplicationUserId == id).ToList();
      return View(thisUser);
    }
  }
}
    //
