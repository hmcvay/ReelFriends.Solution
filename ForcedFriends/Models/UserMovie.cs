using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace ForcedFriends.Models
{
  public class UserMovie 
  {
     public int UserMovieId { get; set; }
    public int UserId { get; set;}
    public int MovieId { get; set; }
    public virtual UserProfile UserProfile {get;set;}
  }
}