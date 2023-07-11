using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BorjaProject.iws.api.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTabla2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorjaP_Dto");

            migrationBuilder.InsertData(
                table: "BorjaPs",
                columns: new[] { "Id", "Edad", "FechaCreacion", "Name", "Peso" },
                values: new object[,]
                {
                    { 1, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karen Cruz", 60 },
                    { 2, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo borja", 90 },
                    { 3, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guerlain Varela", 70 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BorjaPs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BorjaPs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BorjaPs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "BorjaP_Dto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorjaP_Dto", x => x.Id);
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
    }
}
