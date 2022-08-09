using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.DAL.Migrations
{
    public partial class AjusteNomeTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dificuldade_Evolucoes_EvolucaoId",
                table: "Dificuldade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dificuldade",
                table: "Dificuldade");

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

            migrationBuilder.RenameTable(
                name: "Dificuldade",
                newName: "Dificuldades");

            migrationBuilder.RenameIndex(
                name: "IX_Dificuldade_EvolucaoId",
                table: "Dificuldades",
                newName: "IX_Dificuldades_EvolucaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dificuldades",
                table: "Dificuldades",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Estudos",
                columns: new[] { "Id", "Categoria", "DataConclusao", "Descricao", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { new Guid("4d57405a-2046-4c8e-b96e-58337be3f2f9"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building an API is one thing, but building a truly RESTful API is something different. In this course, you'll learn how to build one using ASP.NET Core 3.", "Curso", "Building a RESTful API with ASP.NET Core 3" },
                    { new Guid("e2b27882-743b-453a-bd2a-a56c32d34313"), "Desenvolvimento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way.", "Livro", "Clean Code" },
                    { new Guid("99c46de4-daa4-476b-ab8e-ceed40c8a018"), "Ficção", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King’s Landing", "Livro", "A Game of Thrones" },
                    { new Guid("508b5782-409d-4656-b4e9-7b268afa429b"), "Ciencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O planeta Terra tem cerca de 4,5 bilhões de anos. Numa fração ínfima desse tempo, uma espécie entre incontáveis outras o dominou: nós, humanos. Somos os animais mais evoluídos e mais destrutivos que jamais viveram.", "Livro", "Sapiens" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dificuldades_Evolucoes_EvolucaoId",
                table: "Dificuldades",
                column: "EvolucaoId",
                principalTable: "Evolucoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dificuldades_Evolucoes_EvolucaoId",
                table: "Dificuldades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dificuldades",
                table: "Dificuldades");

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("4d57405a-2046-4c8e-b96e-58337be3f2f9"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("508b5782-409d-4656-b4e9-7b268afa429b"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("99c46de4-daa4-476b-ab8e-ceed40c8a018"));

            migrationBuilder.DeleteData(
                table: "Estudos",
                keyColumn: "Id",
                keyValue: new Guid("e2b27882-743b-453a-bd2a-a56c32d34313"));

            migrationBuilder.RenameTable(
                name: "Dificuldades",
                newName: "Dificuldade");

            migrationBuilder.RenameIndex(
                name: "IX_Dificuldades_EvolucaoId",
                table: "Dificuldade",
                newName: "IX_Dificuldade_EvolucaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dificuldade",
                table: "Dificuldade",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Dificuldade_Evolucoes_EvolucaoId",
                table: "Dificuldade",
                column: "EvolucaoId",
                principalTable: "Evolucoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
