﻿// <auto-generated />
using BlazorCrud.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorCrud.Server.Migrations
{
    [DbContext(typeof(NominasDbContext))]
    [Migration("20231011204827_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorCrud.Server.Models.Entidades.Personal", b =>
                {
                    b.Property<int>("IdPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonal"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRangoPersonal")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonal");

                    b.HasIndex("IdRangoPersonal");

                    b.ToTable("Personals");

                    b.HasData(
                        new
                        {
                            IdPersonal = 1,
                            Celular = "78793467",
                            Correo = "juan@email.com",
                            IdRangoPersonal = 1,
                            Nombres = "Juan"
                        },
                        new
                        {
                            IdPersonal = 2,
                            Celular = "98873432",
                            Correo = "maria@email.com",
                            IdRangoPersonal = 2,
                            Nombres = "María"
                        },
                        new
                        {
                            IdPersonal = 3,
                            Celular = "66341289",
                            Correo = "gerardo@email.com",
                            IdRangoPersonal = 3,
                            Nombres = "Gerardo"
                        });
                });

            modelBuilder.Entity("BlazorCrud.Server.Models.Entidades.RangoPersonal", b =>
                {
                    b.Property<int>("IdRangoPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRangoPersonal"));

                    b.Property<string>("Rangos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRangoPersonal");

                    b.ToTable("RangoPersonals");

                    b.HasData(
                        new
                        {
                            IdRangoPersonal = 1,
                            Rangos = "Administrador"
                        },
                        new
                        {
                            IdRangoPersonal = 2,
                            Rangos = "Gerente"
                        },
                        new
                        {
                            IdRangoPersonal = 3,
                            Rangos = "Colaborador"
                        });
                });

            modelBuilder.Entity("BlazorCrud.Server.Models.Entidades.Personal", b =>
                {
                    b.HasOne("BlazorCrud.Server.Models.Entidades.RangoPersonal", "RangosPersonales")
                        .WithMany("Personales")
                        .HasForeignKey("IdRangoPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RangosPersonales");
                });

            modelBuilder.Entity("BlazorCrud.Server.Models.Entidades.RangoPersonal", b =>
                {
                    b.Navigation("Personales");
                });
#pragma warning restore 612, 618
        }
    }
}
