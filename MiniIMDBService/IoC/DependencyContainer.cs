using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniIMDBService.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services) {
            services.AddScoped<Services.ServiceInterfaces.ISearchIMDB, Services.SearchIMDB>();
            services.AddScoped<Services.ServiceInterfaces.IExceptionLogger, Services.ExceptionLogger>();
        }
    }
}
