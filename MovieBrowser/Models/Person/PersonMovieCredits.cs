using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{
    public class PersonMovieCredits
    {
        public PersonMovieCreditsCast[] cast { get; set; }
        public PersonMovieCreditsCrew[] crew { get; set; }
        public int id { get; set; }
    }

    public class PersonMovieCreditsCast
    {
        public string character { get; set; }
        public string credit_id { get; set; }
        public string release_date { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public bool adult { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public int?[] genre_ids { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public float popularity { get; set; }
        public int id { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }

        public string PosterUri
        {
            get { return "https://image.tmdb.org/t/p/w154/" + poster_path; }
        }
    }

    public class PersonMovieCreditsCrew
    {
        public int id { get; set; }
        public string department { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string job { get; set; }
        public string overview { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public int?[] genre_ids { get; set; }
        public float vote_average { get; set; }
        public bool adult { get; set; }
        public string release_date { get; set; }
        public string credit_id { get; set; }
    }

}
