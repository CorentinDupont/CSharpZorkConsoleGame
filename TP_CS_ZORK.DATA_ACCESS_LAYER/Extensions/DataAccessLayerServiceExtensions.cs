namespace StudentManager.DataAccessLayer.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers;
    using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

    public static class DataAccessLayerServiceExtensions
    {
        /// <summary>
        ///     Extension method use to initialize data access.
        /// </summary>
        /// <param name="services">Collection of the available services for the app.</param>
        /// <returns>Returns edited services collection.</returns>
        public static IServiceCollection AddDataAccessLayerService(this IServiceCollection services)
        {

            services.AddTransient<MonstersAccessLayer>();

            return services;
        }
    }
}
