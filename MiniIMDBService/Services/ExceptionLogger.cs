using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.Services
{
    public class ExceptionLogger : ServiceInterfaces.IExceptionLogger
    {
        public Task<bool> LogExcpeption(string data)
        {
            throw new NotImplementedException();
        }
    }
}
