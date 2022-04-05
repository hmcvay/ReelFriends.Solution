using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace ForcedFriends.Models
{
  public class ApplicationUserMovie 
  {
    public int ApplicationUserMovieId { get; set; }
    public string ApplicationUserId { get; set;}
    public int Id { get; set; }

    public virtual Movie Movie { get; set; }
    // public virtual ApplicationUser ApplicationUser {get;set;}
  }
}