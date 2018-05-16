using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{
    public class Person
    {
        public string birthday { get; set; }
        public object deathday { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<string> also_known_as { get; set; }
        public int gender { get; set; }
        public string biography { get; set; }
        public float popularity { get; set; }
        public string place_of_birth { get; set; }
        public string profile_path { get; set; }
        public bool adult { get; set; }
        public string imdb_id { get; set; }
        public object homepage { get; set; }

        public string ProfileUri
        {
            get { return "https://image.tmdb.org/t/p/w400/" + profile_path; }
        }

        public string GenderString
        {
            get
            {
                if(gender==1) return "Female";
                if(gender==2) return "Male";
                return "Not set";
            }
        }
    }

}
