using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace ForcedFriends.Models
{
  public class UserProfile 
  {
    public UserProfile()
    {
      this.JoinEntities = new HashSet<UserMovie>();
    }
    public int UserId { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Bio { get; set; }
    public string ProfileImg { get; set; }
    public virtual ICollection<UserMovie> JoinEntities {get;set;}
    public virtual ApplicationUser User {get;}
    
  }
}

