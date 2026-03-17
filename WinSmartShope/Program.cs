using Dependency_Injection;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Composition_Root;
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

            services.AddInfraStructer();
            services.AddApplication();

            services.AddTransient<MainForm>();
            services.AddTransient<ListCustomers>();
            services.AddTransient<frmListAccountStatments>();
            services.AddTransient<frmListPages>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

           System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<MainForm>());
            
        }
    }
}