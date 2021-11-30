using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReviewApp.Models
{
    public class Rating
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public float Stars { get; set; }
    }
}
