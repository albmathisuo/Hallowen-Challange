using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila
{
    class Members
    {
        public string username { get; set; }

        public string password { get; set; }
        public string Fullinfo
        {
            get
            {
                return username;
            }
        }
    }
}
