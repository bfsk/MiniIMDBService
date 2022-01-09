using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.DL.Data.Models
{
    public class Cast
    {
        public int Id { get; set; }
        public int? movie_id { get; set; }
        public Movie Movie { get; set; }
        public int? tvshow_id { get; set; }
        public TVShow TVShow { get; set; }
        public int actor_id { get; set; }
        public Actor Actor { get; set; }
    }
}
