// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skynetz.Infra.Context;

namespace Skynetz.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Skynetz.Domain.Models.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Minutos")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Minutos = 30,
                            Nome = "FaleMais 30"
                        },
                        new
                        {
                            Id = 2,
                            Minutos = 60,
                            Nome = "FaleMais 60"
                        },
                        new
                        {
                            Id = 3,
                            Minutos = 120,
                            Nome = "FaleMais 120"
                        });
                });

            modelBuilder.Entity("Skynetz.Domain.Models.Tarifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TarifaMinuto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Tarifas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Destino = "016",
                            Origem = "011",
                            TarifaMinuto = 1.9m
                        },
                        new
                        {
                            Id = 2,
                            Destino = "011",
                            Origem = "016",
                            TarifaMinuto = 2.9m
                        },
                        new
                        {
                            Id = 3,
                            Destino = "017",
                            Origem = "011",
                            TarifaMinuto = 1.7m
                        },
                        new
                        {
                            Id = 4,
                            Destino = "011",
                            Origem = "017",
                            TarifaMinuto = 2.7m
                        },
                        new
                        {
                            Id = 5,
                            Destino = "018",
                            Origem = "011",
                            TarifaMinuto = 0.9m
                        },
                        new
                        {
                            Id = 6,
                            Destino = "011",
                            Origem = "018",
                            TarifaMinuto = 1.9m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
