using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{

    public class PersonTvShowCredits
    {
        public PersonTvShowCreditsCast[] cast { get; set; }
        public PersonTvShowCreditsCrew[] crew { get; set; }
        public int id { get; set; }
    }

    public class PersonTvShowCreditsCast
    {
        public string credit_id { get; set; }
        public string original_name { get; set; }
        public int id { get; set; }
        public int?[] genre_ids { get; set; }
        public string character { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public int vote_count { get; set; }
        public float vote_average { get; set; }
        public float popularity { get; set; }
        public int episode_count { get; set; }
        public string original_language { get; set; }
        public string first_air_date { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string[] origin_country { get; set; }

        public string PosterUri
        {
            get { return "https://image.tmdb.org/t/p/w154/" + poster_path; }
        }
    }

    public class PersonTvShowCreditsCrew
    {
        public int id { get; set; }
        public string department { get; set; }
        public string original_language { get; set; }
        public int episode_count { get; set; }
        public string job { get; set; }
        public string overview { get; set; }
        public string[] origin_country { get; set; }
        public string original_name { get; set; }
        public int[] genre_ids { get; set; }
        public string name { get; set; }
        public string first_air_date { get; set; }
        public string backdrop_path { get; set; }
        public float popularity { get; set; }
        public int vote_count { get; set; }
        public float vote_average { get; set; }
        public string poster_path { get; set; }
        public string credit_id { get; set; }
    }

}
