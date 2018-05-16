using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{

    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public List<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public float popularity { get; set; }
        public object poster_path { get; set; }
        public List<ProductionCompanies> production_companies { get; set; }
        public List<ProductionCountries> production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguages> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        private string _overview;
        public string Overview
        {
            get
            {
                if (_overview == null) return "No overview has been added.";
                else return _overview;
            }
            set { _overview = value; }
        }

        public string PosterUri
        {
            get { return "https://image.tmdb.org/t/p/w400/" + poster_path; }
        }

        public string BackdropUri
        {
            get { return "https://image.tmdb.org/t/p/w780/" + backdrop_path; }
        }

        /// <summary>
        /// Concatenates the genres separated by commas.
        /// </summary>
        public string GenreNames
        {
            get
            {
                string ret = "";
                if (genres.Count != 0)
                {
                    for (int i = 0; i < genres.Count - 1; i++)
                    {
                        ret += $"{genres[i].name}, ";
                    }
                    ret += genres[genres.Count - 1].name;
                }
                else ret = "No genres have been added.";
                return ret;
            }
        }

        /// <summary>
        /// Concatenates the production companies separated by commas.
        /// </summary>
        public string ProductionCompanyNames
        {
            get
            {
                string ret = "";
                if (production_companies.Count != 0)
                {
                    for (int i = 0; i < production_companies.Count - 1; i++)
                    {
                        ret += $"{production_companies[i].name}, ";
                    }
                    ret += production_companies[production_companies.Count - 1].name;
                }
                else ret = "No production companies have been added.";
                return ret;
            }
        }

    }

    public class ProductionCountries
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class SpokenLanguages
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }

}
