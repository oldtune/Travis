using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travis.Models
{
    public class NewsKeywordModel
    {
        public NewsKeywordModel()
        {
            Links = new List<string>();
        }

        public string Keyword { set; get; }
        public List<string> Links { set; get; }
        public int AppearCount => Links.Count;
    }
}
