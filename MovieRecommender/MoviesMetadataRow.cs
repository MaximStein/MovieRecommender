using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender
{
    public class MoviesMetadataRow
    {
        public string Id { get; set; }
        public string OriginalTitle { get; set; }
        public string ImdbId { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double? Popularity { get; set; }
        public double? VoteAverage { get; set; }
        public double? VoteCount { get; set; }
        public double? Runtime { get; set; }

        public String NiceString { get { return OriginalTitle + " (" + ReleaseDate.Year + ")"; } }

        public String ToString()
        {
            return "" + Id + "|" + OriginalTitle + "|" + ImdbId;
        }
    }
}
