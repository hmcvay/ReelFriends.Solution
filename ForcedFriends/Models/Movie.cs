using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ForcedFriends.Models
{
  public class Movie
  {
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int ReleaseDate { get; set; }
    public string Url { get; set; }

    public static List<Movie> GetMovies(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonResponse["results"].ToString());
      return movieList;
    }
  }
}