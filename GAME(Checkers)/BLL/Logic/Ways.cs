using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class Ways
    {



       public List<string[]> ListWays;

        public string[] DoubleWayG1A7 = new string[] { "g1","f2","e3","d4","c5","b6","a7" };
        public string[] DoubleWayH2B8 = new string[] { "h2","g3","f4","e5","d6","c7","b8" };
        public string[] TripleWayC1A3 = new string[] { "c1","b2","a3"};
        public string[] TripleWayC1H6 = new string[] { "c1","d2","e3","f4","g5","h6"};
        public string[] TripleWayH6F8 = new string[] { "h6","g7","f8"};
        public string[] TripleWayA3F8 = new string[] { "a3","b4","c5","d6","e7","f8"};
        public string[] UltraWayA5D8 = new string[] { "a5","b6","c7","d8"};
        public string[] UltraWayH4D8 = new string[] { "h4","g5","f6","e7","d8"};
        public string[] UltraWayE1A5 = new string[] { "e1","d2","c3","b4","a5"};
        public string[] UltraWayE1H4 = new string[] { "e1","f2","g3","h4"};

        
        public List<string[]> GetWays()
        {
            ListWays = new List<string[]>() {DoubleWayG1A7,DoubleWayH2B8 ,TripleWayC1A3 ,TripleWayC1H6 ,TripleWayH6F8 ,TripleWayA3F8 ,UltraWayA5D8,UltraWayH4D8,UltraWayE1A5,UltraWayE1H4};
            return ListWays;
        }


    }
}
