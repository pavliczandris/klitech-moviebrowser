using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{
    public class PopularTvShowsList
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<ResultTvShow> results { get; set; }
    }

    public class ResultTvShow
    {
        public string original_name { get; set; }
        public int[] genre_ids { get; set; }
        public string name { get; set; }
        public float popularity { get; set; }
        public string[] origin_country { get; set; }
        public int vote_count { get; set; }
        public string first_air_date { get; set; }
        public string backdrop_path { get; set; }
        public string original_language { get; set; }
        public int id { get; set; }
        public float vote_average { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }

        public string PosterUri
        {
            get { return "https://image.tmdb.org/t/p/w300/" + poster_path; }
        }
    }

}
