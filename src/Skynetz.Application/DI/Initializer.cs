using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skynetz.Domain.Interfaces;
using Skynetz.Domain.Models;
using Skynetz.Infra.Context;
using Skynetz.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynetz.Application.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conection));
            services.AddScoped(typeof(IRepository<Tarifa>), typeof(TarifaRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(TarifaService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
