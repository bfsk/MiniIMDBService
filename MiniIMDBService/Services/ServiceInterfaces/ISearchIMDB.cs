using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.Services.ServiceInterfaces
{
    public interface ISearchIMDB
    {
        Task<IEnumerable<Data.Views.TopMovie>> GetByQuery(string query);
    }
}
