using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.DL.Data.Models
{
    public class TVShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public double Score { get; set; }
        public int NumberOfVotes { get; set; }
        public string ImageLocation { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DL.Data.Models.Cast> Casts { get; set; }
    }
}
