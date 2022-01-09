using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.DL.Data.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<DL.Data.Models.Cast> Casts { get; set; }
    }
}
