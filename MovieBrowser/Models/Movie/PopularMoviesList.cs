using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{
    public class PopularMoviesList
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<ResultMovie> results { get; set; }
    }

    public class ResultMovie
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public int?[] genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }

        public string PosterUri
        {
            get { return "https://image.tmdb.org/t/p/w300/" + poster_path; }
        }

    }

}
