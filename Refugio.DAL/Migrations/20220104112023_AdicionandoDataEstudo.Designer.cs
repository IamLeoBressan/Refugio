﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Refugio.DAL.DbContexts;

namespace Refugio.DAL.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20220104112023_AdicionandoDataEstudo")]
    partial class AdicionandoDataEstudo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Refugio.Entities.Dificuldade", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvolucaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvolucaoId");

                    b.ToTable("Dificuldade");
                });

            modelBuilder.Entity("Refugio.Entities.Estudo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataConclusao")
                        .HasColumnType("datetime2");

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
                            Id = new Guid("27207e28-ff3b-4122-ad80-dd6ab9c5db16"),
                            Categoria = "Desenvolvimento",
                            DataConclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.",
                            Tipo = "Curso",
                            Titulo = "Building a RESTful API with ASP.NET Core 3"
                        },
                        new
                        {
                            Id = new Guid("1a68d9af-87dd-44c3-a0e5-808d8daaf57f"),
                            Categoria = "Desenvolvimento",
                            DataConclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.",
                            Tipo = "Livro",
                            Titulo = "Clean Code"
                        },
                        new
                        {
                            Id = new Guid("2332a60a-f9e2-4a0f-ac06-1261f511f626"),
                            Categoria = "Ficção",
                            DataConclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing",
                            Tipo = "Livro",
                            Titulo = "A Game of Thrones"
                        },
                        new
                        {
                            Id = new Guid("5e9c0d80-88ef-48ce-8f37-ef429ada153f"),
                            Categoria = "Ciencia",
                            DataConclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.",
                            Tipo = "Livro",
                            Titulo = "Sapiens"
                        });
                });

            modelBuilder.Entity("Refugio.Entities.Evolucao", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataMedicao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnviarEmail")
                        .HasColumnType("bit");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Evolucoes");
                });

            modelBuilder.Entity("Refugio.Entities.Objetivo", b =>
                {
                    b.Property<int?>("Id")
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

            modelBuilder.Entity("Refugio.Entities.Dificuldade", b =>
                {
                    b.HasOne("Refugio.Entities.Evolucao", "Evolucao")
                        .WithMany("Dificuldades")
                        .HasForeignKey("EvolucaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evolucao");
                });

            modelBuilder.Entity("Refugio.Entities.Evolucao", b =>
                {
                    b.Navigation("Dificuldades");
                });
#pragma warning restore 612, 618
        }
    }
}