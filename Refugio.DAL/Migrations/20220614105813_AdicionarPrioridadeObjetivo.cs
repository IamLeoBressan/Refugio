using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.DAL.Migrations
{
    public partial class AdicionarPrioridadeObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Objetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "DataConclusao", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("82d5b2e5-22b3-438b-a719-521ddd795429"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("46d0bb82-5eae-4004-8d02-a829c1fdbecf"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("4c1b3795-2ad6-4f90-8e4a-fea0d6ef5266"), "Ficção", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("f8c763b3-a949-4401-95c3-96885ecd550c"), "Ciencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("46d0bb82-5eae-4004-8d02-a829c1fdbecf"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("4c1b3795-2ad6-4f90-8e4a-fea0d6ef5266"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("82d5b2e5-22b3-438b-a719-521ddd795429"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("f8c763b3-a949-4401-95c3-96885ecd550c"));

            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Objetivos");

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
    }
}
