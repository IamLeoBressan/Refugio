using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.DAL.Migrations
{
    public partial class AdicionandoUsuarioEvolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("456e31cf-394a-44cf-8d8d-cd8d417cf6ee"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("70453e44-f2e9-4faf-bf04-f3c00139e8ef"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("ee6b06a6-fd5d-4245-823d-ec69e4902824"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("efd73e8c-51e1-4ad3-8cae-e74021edb78a"));

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Evolucoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "DataConclusao", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("359b01fe-3092-411c-9876-d1c75e4e2db1"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("e4abd9b0-84ab-4312-9397-6167302485ed"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("7e2efa6f-9f6f-4db3-871c-a33331434c37"), "Ficção", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("c92334fd-fc63-49d4-80d4-7f24ff468e1f"), "Ciencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("359b01fe-3092-411c-9876-d1c75e4e2db1"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("7e2efa6f-9f6f-4db3-871c-a33331434c37"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("c92334fd-fc63-49d4-80d4-7f24ff468e1f"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("e4abd9b0-84ab-4312-9397-6167302485ed"));

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Evolucoes");

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "DataConclusao", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("70453e44-f2e9-4faf-bf04-f3c00139e8ef"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("456e31cf-394a-44cf-8d8d-cd8d417cf6ee"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("ee6b06a6-fd5d-4245-823d-ec69e4902824"), "Ficção", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("efd73e8c-51e1-4ad3-8cae-e74021edb78a"), "Ciencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }
    }
}
