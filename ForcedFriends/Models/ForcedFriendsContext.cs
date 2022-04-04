using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForcedFriends.Models
{
  public class ForcedFriendsContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserMovie> UserMovies { get; set; }
    public ForcedFriendsContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}