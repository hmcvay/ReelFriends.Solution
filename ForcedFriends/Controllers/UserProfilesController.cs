using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ForcedFriends.Models;
using System.Threading.Tasks;
using ForcedFriends.ViewModels;
using System.Security.Claims;


namespace ForcedFriends.Controllers
{
  public class UserProfilesController : Controller
  {
    private readonly ForcedFriendsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public UserProfilesController(UserManager<ApplicationUser> userManager, ForcedFriendsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      
      return View();
    }
    public ActionResult Edit()
    {
      return View();
    }
    
  //   [HttpPost]
  //   public 
  // } 
  }
}

// var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
// var currentUser = await _userManager.FindByIdAsync(userId);
// var userItems = _db.Items.Where(entry => entry.User.Id == currentUser.Id).ToList();
// return View(_db.Items.ToList());