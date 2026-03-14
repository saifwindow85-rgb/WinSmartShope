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
            services.AddTransient<MainForm>();
            services.AddTransient<ListCustomers>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

           System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<MainForm>());
            
        }
    }
}