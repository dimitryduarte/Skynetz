using Microsoft.EntityFrameworkCore;
using Skynetz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynetz.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Tarifa> Tarifas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarifa>().HasData(
                     new Tarifa
                     {
                         Id = 1,
                         Origem = "011",
                         Destino = "016",
                         TarifaMinuto = (decimal)1.90
                     },
                     new Tarifa
                     {
                         Id = 2,
                         Origem = "016",
                         Destino = "011",
                         TarifaMinuto = (decimal)2.90
                     },
                     new Tarifa
                     {
                         Id = 3,
                         Origem = "011",
                         Destino = "017",
                         TarifaMinuto = (decimal)1.70
                     },
                     new Tarifa
                     {
                         Id = 4,
                         Origem = "017",
                         Destino = "011",
                         TarifaMinuto = (decimal)2.70
                     },
                     new Tarifa
                     {
                         Id = 5,
                         Origem = "011",
                         Destino = "018",
                         TarifaMinuto = (decimal)0.90
                     },
                     new Tarifa
                     {
                         Id = 6,
                         Origem = "018",
                         Destino = "011",
                         TarifaMinuto = (decimal)1.90
                     }
             );
        }
    }
}
