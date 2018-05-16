using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{

    public class TvShow
    {
        public string backdrop_path { get; set; }
        public List<Created_By> created_by { get; set; }
        public List<int> episode_run_time { get; set; }
        public string first_air_date { get; set; }
        public List<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public bool in_production { get; set; }
        public List<string> languages { get; set; }
        public string last_air_date { get; set; }
        public string name { get; set; }
        public List<Network> networks { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public List<string> origin_country { get; set; }
        public string original_language { get; set; }
        public string original_name { get; set; }
        //public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompanies> production_companies { get; set; }
        public List<Season> seasons { get; set; }
        public string status { get; set; }
        public string type { get; set; }
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

    public class Created_By
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
    }

    public class Network
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
