﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Refugio.DAL.DbContexts;

namespace Refugio.DAL.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Refugio.Entities.Estudo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estudos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6ce689a3-3620-46a9-b13c-8a79e479efb6"),
                            Categoria = "Desenvolvimento",
                            Descricao = "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.",
                            Tipo = "Curso",
                            Titulo = "Building a RESTful API with ASP.NET Core 3"
                        },
                        new
                        {
                            Id = new Guid("8daa9fe2-b8ca-442a-8093-f3f29b545679"),
                            Categoria = "Desenvolvimento",
                            Descricao = "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.",
                            Tipo = "Livro",
                            Titulo = "Clean Code"
                        },
                        new
                        {
                            Id = new Guid("cefcddb2-c0d7-4988-b8a7-de8c79b0ce89"),
                            Categoria = "Ficção",
                            Descricao = "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing",
                            Tipo = "Livro",
                            Titulo = "A Game of Thrones"
                        },
                        new
                        {
                            Id = new Guid("12e73e6b-7c2c-4ef0-ba06-ea71eb8f75c9"),
                            Categoria = "Ciencia",
                            Descricao = "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.",
                            Tipo = "Livro",
                            Titulo = "Sapiens"
                        });
                });

            modelBuilder.Entity("Refugio.Entities.Objetivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Objetivos");
                });
#pragma warning restore 612, 618
        }
    }
}
