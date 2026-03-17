using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Servs;
using WinSmartShope.Views;

namespace WinSmartShope
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            ApplicationConfiguration.Initialize();
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<AppDbContext>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CustomerServices>();

            services.AddScoped<IAccountStatement, AccountStatementRepository>();
            services.AddScoped<AccountStatementServices>();

            services.AddScoped<IDebtPage, DebtPagesRepository>();
            services.AddScoped<DebtPagesServices>();


            services.AddTransient<MainForm>();
            services.AddTransient<ListCustomers>();
            services.AddTransient<frmListAccountStatments>();
            services.AddTransient<frmListPages>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

           System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<MainForm>());
            
        }
    }
}