using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.DL.Data.Views
{
    public class TopContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public double Score { get; set; }
        public string ImageLocation { get; set; }
        public string Description { get; set; }
        public ICollection<DL.Data.Views.ActorView> Actors { get; set; }
    }
}
