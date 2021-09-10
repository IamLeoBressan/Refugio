using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.DAL.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("1ffb016d-d7e5-4218-b3d4-6ecd7760943b"), "Desenvolvimento", "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("48b95ded-b551-4e2b-80e1-5262a33ae350"), "Desenvolvimento", "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("e7836278-3c02-436f-af31-d696bc51b930"), "Ficção", "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("e6453a2b-c224-4093-9f0b-ef53d2d39621"), "Ciencia", "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudos");
        }
    }
}
