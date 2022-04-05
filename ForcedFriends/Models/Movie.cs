using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ForcedFriends.Models
{
  public class Movie
  {
    public int Id { get; set; }
    //public int MovieName { get; set; }
    public string Title { get; set; }
    public string Release_Date { get; set; }

    public string Tagline { get; set; }
    public string Overview { get; set; }
    public string Poster_Path { get; set; }
    public virtual ApplicationUser ApplicationUser {get;set;}

    public static List<Movie> GetMovies(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey);
      var result = apiCallTask.Result;
      List<Movie> movieNameList= new List<Movie>{} ;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);

      List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonResponse["results"].ToString());
      // foreach(var movie in movieList )
      // {
      //   Console.WriteLine(movie.Title);
      //   db.Movies.Add(movie);
      //   movie.MovieId = movie.Id;
      //   delete move.Id
      // }
      return movieList;
    }
    public static Movie GetMovie(string apiKey, int id)
    {
      var apiCallTask = ApiHelper.SingleMovieCall(apiKey, id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Movie thisMovie = JsonConvert.DeserializeObject<Movie>(jsonResponse.ToString());
      return thisMovie;
    }
  }
}