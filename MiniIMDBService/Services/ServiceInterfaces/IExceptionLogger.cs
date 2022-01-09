using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.Services.ServiceInterfaces
{
    public interface IExceptionLogger
    {
        Task<bool> LogExcpeption(string data);
    }
}
