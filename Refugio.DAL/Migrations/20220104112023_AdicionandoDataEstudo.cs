using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.DAL.Migrations
{
    public partial class AdicionandoDataEstudo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("37d42e2a-a19e-485d-a374-8a756c389484"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("785218f4-fb36-435c-a173-93ddc7cc1112"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("b266c0bb-3bc4-4f56-acae-151b403e7ab3"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("e3da731a-ff25-4b60-82a6-e4d8d19b776d"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "Estudos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "DataConclusao", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("27207e28-ff3b-4122-ad80-dd6ab9c5db16"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("1a68d9af-87dd-44c3-a0e5-808d8daaf57f"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("2332a60a-f9e2-4a0f-ac06-1261f511f626"), "Ficção", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("5e9c0d80-88ef-48ce-8f37-ef429ada153f"), "Ciencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("1a68d9af-87dd-44c3-a0e5-808d8daaf57f"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("2332a60a-f9e2-4a0f-ac06-1261f511f626"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("27207e28-ff3b-4122-ad80-dd6ab9c5db16"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("5e9c0d80-88ef-48ce-8f37-ef429ada153f"));

            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "Estudos");

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("b266c0bb-3bc4-4f56-acae-151b403e7ab3"), "Desenvolvimento", "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("e3da731a-ff25-4b60-82a6-e4d8d19b776d"), "Desenvolvimento", "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("785218f4-fb36-435c-a173-93ddc7cc1112"), "Ficção", "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("37d42e2a-a19e-485d-a374-8a756c389484"), "Ciencia", "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });
        }
    }
}
