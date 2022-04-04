using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ForcedFriends.Models
{
  public class ForcedFriendsContextFactory : IDesignTimeDbContextFactory<ForcedFriendsContext>
  {

    ForcedFriendsContext IDesignTimeDbContextFactory<ForcedFriendsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<ForcedFriendsContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new ForcedFriendsContext(builder.Options);
    }
  }
}