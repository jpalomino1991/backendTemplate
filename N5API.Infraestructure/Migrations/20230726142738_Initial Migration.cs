using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N5API.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPermiso = table.Column<int>(type: "int", nullable: false),
                    FechaPermiso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Permission Type 1" },
                    { 2, "Permission Type 2" },
                    { 3, "Permission Type 3" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "FechaPermiso", "NombreEmpleado", "TipoPermiso", "PermissionTypeId", "ApellidoEmpleado" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 26, 9, 27, 38, 730, DateTimeKind.Local).AddTicks(5718), "ForeName 1 ", 1, null, "SurName 1 " },
                    { 2, new DateTime(2023, 7, 26, 9, 27, 38, 730, DateTimeKind.Local).AddTicks(5730), "ForeName 2 ", 1, null, "SurName 2 " },
                    { 3, new DateTime(2023, 7, 26, 9, 27, 38, 730, DateTimeKind.Local).AddTicks(5732), "ForeName 3 ", 2, null, "SurName 3 " },
                    { 4, new DateTime(2023, 7, 26, 9, 27, 38, 730, DateTimeKind.Local).AddTicks(5733), "ForeName 4 ", 3, null, "SurName 4 " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeId",
                table: "Permissions",
                column: "PermissionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTypes");
        }
    }
}
