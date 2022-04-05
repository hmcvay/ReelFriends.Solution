using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForcedFriends.Models
{
  public class ForcedFriendsContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<ApplicationUserMovie> ApplicationUserMovies { get; set; }
    public DbSet<Movie> Movies {get;set;}
    public ForcedFriendsContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}