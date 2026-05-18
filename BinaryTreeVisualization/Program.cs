using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace BinaryTreeVisualization
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug().WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            ServiceCollection services = new();

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog();
            });

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            Application.Run(
                new FormVisualization(serviceProvider.GetService<ILogger<FormVisualization>>())
            );

            Log.CloseAndFlush();
        }
    }
}