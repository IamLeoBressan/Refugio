using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.WebApi.Migrations
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
                    { new Guid("4f9756a1-45bc-4e2f-aeb8-48a69e0b2288"), "Desenvolvimento", "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("db045230-1efb-4142-ac04-6a3a4d72a13e"), "Desenvolvimento", "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("12cebd5d-13d8-4bc1-93f7-e573349f5c47"), "Ficção", "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("a172d006-266a-4b4d-a69b-72bae674f802"), "Ciencia", "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudos");
        }
    }
}
