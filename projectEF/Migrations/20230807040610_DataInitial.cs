using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class DataInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("71c3ac95-768d-4d95-bff8-e523f2a37201"), null, "Tareas Personbales", 20 },
                    { new Guid("71c3ac95-768d-4d95-bff8-e523f2a37202"), null, "Tareas Laborales", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("71c3ac95-768d-4d95-bff8-e523f2a37210"), new Guid("71c3ac95-768d-4d95-bff8-e523f2a37201"), null, new DateTime(2023, 8, 6, 22, 6, 10, 585, DateTimeKind.Local).AddTicks(6726), 0, "Ir GYM" },
                    { new Guid("71c3ac95-768d-4d95-bff8-e523f2a37211"), new Guid("71c3ac95-768d-4d95-bff8-e523f2a37202"), null, new DateTime(2023, 8, 6, 22, 6, 10, 585, DateTimeKind.Local).AddTicks(6744), 2, "Presentar API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareId",
                keyValue: new Guid("71c3ac95-768d-4d95-bff8-e523f2a37210"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareId",
                keyValue: new Guid("71c3ac95-768d-4d95-bff8-e523f2a37211"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("71c3ac95-768d-4d95-bff8-e523f2a37201"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("71c3ac95-768d-4d95-bff8-e523f2a37202"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
