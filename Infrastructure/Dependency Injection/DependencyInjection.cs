using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Composition_Root
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructer(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IAccountStatement, AccountStatementRepository>();

            services.AddScoped<IDebtPage, DebtPagesRepository>();
            return services;
        }
    }
}
