using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Pocos
{
    public class RecommenderResult
    {
        public string title { get; set; }
        public int vote_count { get; set; }
        public int vote_average { get; set; }
        public string year { get; set; }
        public int id { get; set; }
        public double sim_score { get; set; }
        public double weighted_rating { get; set; }
        public double order_score { get; set; }
    
        public override string ToString()
        {
            return id + " | " + title + " (" + year + ") | order_score: " + order_score + " | sim_score: " + sim_score;
        }
    }
}
