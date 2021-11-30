using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
    }
}
