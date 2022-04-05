using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace ForcedFriends.Models
{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser()
    {
      this.JoinEntities = new HashSet<ApplicationUserMovie>();
    }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Bio { get; set; }
    public string ProfileImg { get; set; }
    public virtual ICollection<ApplicationUserMovie> JoinEntities {get;set;}

  }
}