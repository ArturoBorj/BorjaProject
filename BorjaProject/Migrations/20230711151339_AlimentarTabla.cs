using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BorjaProject.iws.api.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorjaP_Dto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorjaP_Dto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorjaPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorjaPs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BorjaP_Dto",
                columns: new[] { "Id", "Edad", "Name", "Peso" },
                values: new object[,]
                {
                    { 1, 24, "Karen Cruz", 60 },
                    { 2, 25, "Arturo borja", 90 },
                    { 3, 30, "Guerlain Varela", 70 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorjaP_Dto");

            migrationBuilder.DropTable(
                name: "BorjaPs");
        }
    }
}
