using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using RentaCar.Domain.Interfaces;
using RentaCar.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentaCar.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionString));
            services.AddScoped<ICarRepository, CarRepository>();
            return services;
        }
    }
}
