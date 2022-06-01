using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Refugio.DAL.Migrations
{
    public partial class AdicionandoCampoImagensNaEvolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvolucaoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BytesImagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Evolucoes_EvolucaoId",
                        column: x => x.EvolucaoId,
                        principalTable: "Evolucoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_EvolucaoId",
                table: "Imagens",
                column: "EvolucaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");

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
    }
}
