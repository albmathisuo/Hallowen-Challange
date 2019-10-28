using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila
{
    public class User
    {
        public int film_id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        public string Fullinfo
        {
            get
            {
                return film_id + "   " + title;
            }
        }
        public string FullinfoDescription
        {
            get
            {
                return title + "   " + name + "   " + description;
            }
        }
    }
}

