using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace ForcedFriends.Models
{
  public class ApplicationUserMovie 
  {
    public int ApplicationUserMovieId { get; set; }
    public int ApplicationUserId { get; set;}
    public int MovieId { get; set; }
    public virtual ApplicationUser ApplicationUser {get;set;}
  }
}