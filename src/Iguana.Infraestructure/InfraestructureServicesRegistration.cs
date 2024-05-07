using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iguana.Api.Models;
using Microsoft.EntityFrameworkCore;
using Iguana.Application.Contracts;
using Iguana.Infraestructure.Repository;

namespace Iguana.Infraestructure
{
    public static class InfraestructureServicesRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICargo, CargoRepo>();
            services.AddScoped<IDepartamento, DepartamentoRepo>();
            services.AddScoped<IUser, UserRepo>();

            services.AddDbContext<PruebasContext>(options => options.UseSqlServer(configuration.GetConnectionString("pruebas")));
            return services;
        }
    }
}
