using Microsoft.Extensions.DependencyInjection;
using Servs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services )
        {
            services.AddScoped<CustomerServices>();

            services.AddScoped<AccountStatementServices>();

            services.AddScoped<DebtPagesServices>();
            return services;
        }
    }
}
