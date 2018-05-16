using MovieBrowser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Services
{
    class MovieBrowserService
    {
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/3/");
        private readonly String apiKey = "a47443f6ac1826f1b0adcc999e586210";


        /// <summary>
        /// A generic method for api calls. It sends an asynchronous request to the given URI and parses the result.
        /// If exception is thrown, it returns a default object.
        /// </summary>
        /// <typeparam name="T">Type of the requested object</typeparam>
        /// <param name="uri">The URI for the API call</param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(uri);
                    var json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message + e.StackTrace);
                    return default(T);
                }

            }
        }


        //Movies

        /// <summary>
        /// Sends a request asynchronously to get the most popular movies.
        /// </summary>
        /// <returns></returns>
        public async Task<PopularMoviesList> GetPopularMovies()
        {
            return await GetAsync<PopularMoviesList>(new Uri(serverUrl, $"movie/popular?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the movie with the given id.
        /// </summary>
        /// <param name="movieId">ID of the movie</param>
        /// <returns></returns>
        public async Task<Movie> GetMovie(int movieId)
        {
            return await GetAsync<Movie>(new Uri(serverUrl, $"movie/{movieId}?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the cast and crew for a movie.
        /// </summary>
        /// <param name="movieId">ID of the movie</param>
        /// <returns></returns>
        public async Task<Credits> GetMovieCredits(int movieId)
        {
            return await GetAsync<Credits>(new Uri(serverUrl, $"movie/{movieId}/credits?api_key={apiKey}"));
        }


        //TvShows


        /// <summary>
        /// Sends a request asynchronously to get the most popular tv shows.
        /// </summary>
        /// <returns></returns>
        public async Task<PopularTvShowsList> GetPopularTvShows()
        {
            return await GetAsync<PopularTvShowsList>(new Uri(serverUrl, $"tv/popular?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the tv show with the given id.
        /// </summary>
        /// <param name="tvShowId">ID of the tv show</param>
        /// <returns></returns>
        public async Task<TvShow> GetTvShow(int tvShowId)
        {
            return await GetAsync<TvShow>(new Uri(serverUrl, $"tv/{tvShowId}?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the cast and crew for a tv show.
        /// </summary>
        /// <param name="tvShowId">ID of the tv show</param>
        /// <returns></returns>
        public async Task<Credits> GetTvShowCredits(int tvShowId)
        {
            return await GetAsync<Credits>(new Uri(serverUrl, $"tv/{tvShowId}/credits?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the TV season details by id.
        /// </summary>
        /// <param name="tvShowId">ID of the tv show</param>
        /// <param name="seasonNumber">Number of the season</param>
        /// <returns></returns>
        public async Task<Season> GetSeason(int tvShowId, int seasonNumber)
        {
            return await GetAsync<Season>(new Uri(serverUrl, $"tv/{tvShowId}/season/{seasonNumber}?api_key={apiKey}"));
        }


        //People

        /// <summary>
        /// Sends a request asynchronously to get a person.
        /// </summary>
        /// <param name="personId">ID of the person</param>
        /// <returns></returns>
        public async Task<Person> GetPerson(int personId)
        {
            return await GetAsync<Person>(new Uri(serverUrl, $"person/{personId}?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the movie credits for a person.
        /// </summary>
        /// <param name="personId">ID of the person</param>
        /// <returns></returns>
        public async Task<PersonMovieCredits> GetPersonMovieCredits(int personId)
        {
            return await GetAsync<PersonMovieCredits>(new Uri(serverUrl, $"person/{personId}/movie_credits?api_key={apiKey}"));
        }

        /// <summary>
        /// Sends a request asynchronously to get the tv show credits for a person.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<PersonTvShowCredits> GetPersonTvShowCredits(int personId)
        {
            return await GetAsync<PersonTvShowCredits>(new Uri(serverUrl, $"person/{personId}/tv_credits?api_key={apiKey}"));
        }

        // Search

        /// <summary>
        /// Sends a request asynchronously to search multiple models in a single request.
        /// Multi search currently supports searching for movies, tv shows and people in a single request.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public async Task<SearchMulti> SearchMulti(string queryString)
        {
            return await GetAsync<SearchMulti>(new Uri(serverUrl, $"search/multi?api_key={apiKey}&query={queryString}"));
        }
    }
}
