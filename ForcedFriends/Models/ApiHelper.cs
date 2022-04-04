using System.Threading.Tasks;
using RestSharp;

namespace ForcedFriends.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey)
    {
      RestClient client = new RestClient("https://api.themoviedb.org/3/movie/popular?api_key={apiKey}f&language=en-US&page=1");
      RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

//  public static async Task<string> ApiCall(string apiKey)
//     {
//       RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
//       RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }