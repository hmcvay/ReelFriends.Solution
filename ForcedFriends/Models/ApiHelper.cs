using System.Threading.Tasks;
using RestSharp;
using System;

namespace ForcedFriends.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey)
    {
      RestClient client = new RestClient("https://api.themoviedb.org/3/movie");
      RestRequest request = new RestRequest("popular?api_key=95b4acf4153f28be0a4560611c9fcadf&language=en-US&page=1",Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> SingleMovieCall(string apiKey, int id)
    {
      RestClient client = new RestClient("https://api.themoviedb.org/3/movie");
      RestRequest request = new RestRequest($"{id}?{apiKey}", Method.GET);

      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

//https://api.themoviedb.org/3/movie/550?api_key=95b4acf4153f28be0a4560611c9fcadf
//https://api.themoviedb.org/3/movie/{movie_id}?api_key=<<api_key>>&language=en-US

//  public static async Task<string> ApiCall(string apiKey)
//     {
//       RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
//       RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }