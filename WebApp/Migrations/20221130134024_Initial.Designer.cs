// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Models;

namespace WebApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221130134024_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PolizaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolizaId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("WebApp.Models.Poliza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datos_tomador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_inicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_vencimiento_poliza_actual")
                        .HasColumnType("datetime2");

                    b.Property<string>("Placa_Automotor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Polizas");
                });

            modelBuilder.Entity("WebApp.Models.Ciudad", b =>
                {
                    b.HasOne("WebApp.Models.Poliza", null)
                        .WithMany("Ciudades")
                        .HasForeignKey("PolizaId");
                });

            modelBuilder.Entity("WebApp.Models.Poliza", b =>
                {
                    b.Navigation("Ciudades");
                });
#pragma warning restore 612, 618
        }
    }
}
