using Microsoft.EntityFrameworkCore;
using Refugio.Entities;
using System;

namespace Refugio.DAL.DbContexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
        public DbSet<Estudo> Estudos { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudo>().HasData(
                new Estudo()
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Curso",
                    Categoria = "Desenvolvimento",
                    Titulo = "Building a RESTful API with ASP.NET Core 3",
                    Descricao = "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3."
                },
                new Estudo()
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Livro",
                    Categoria = "Desenvolvimento",
                    Titulo = "Clean Code",
                    Descricao = "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way."
                },
                new Estudo()
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Livro",
                    Categoria = "Ficção",
                    Titulo = "A Game of Thrones",
                    Descricao = "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing"
                },
                new Estudo()
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Livro",
                    Categoria = "Ciencia",
                    Titulo = "Sapiens",
                    Descricao = "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram."
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
