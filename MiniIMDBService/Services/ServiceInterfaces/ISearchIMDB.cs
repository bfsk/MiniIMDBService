using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.Services.ServiceInterfaces
{
    public interface ISearchIMDB
    {
        Task<IEnumerable<DL.Data.Views.TopContent>> GetByQuery(string query, bool contentType, int page = 0);
    }
}
