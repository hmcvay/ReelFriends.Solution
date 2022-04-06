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

    //     [HttpGet]
    // public ActionResult GetWatchList()
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //  // var watchList = _db.ApplicationUserMovies.Where(m => m.ApplicationUserId == userId).ToList();
    //         var thisUser = _db.ApplicationUsers
    //       .Include(m => m.JoinEntities)
    //       .ThenInclude(m => m.Movie)
    //       .FirstOrDefault(m => m.ApplicationUserId == userId);
    //   return View(thisUser);
    //   //return View(watchList);
    
    // }
  }
}

//  public ActionResult Details(int id)
//     {
//       var thisItem = _db.Items
//           .Include(item => item.JoinEntities)
//           .ThenInclude(join => join.Category)
//           .FirstOrDefault(item => item.ItemId == id);
//       return View(thisItem);
//     }


// IdentityResult result = await userManager.UpdateAsync(user);
// if (result.Succeeded)
// return RedirectToAction("Index");
// else
// Errors(result);
// }

    // public async Task<ActionResult> Edit(int id)
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   var thisItem = _db.Items
    //       .Where(entry => entry.User.Id == currentUser.Id)
    //       .FirstOrDefault(item => item.ItemId == id);
    //   if (thisItem == null)
    //   {
    //     return RedirectToAction("Details", new {id = id});
    //   }
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name"); 
    //   return View(thisItem);
    // }


    // [HttpPost]
    // public ActionResult Edit(Item item, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //   }
    //   _db.Entry(item).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
