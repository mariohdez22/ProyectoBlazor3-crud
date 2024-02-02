using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCrud.Server.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RangoPersonals",
                columns: table => new
                {
                    IdRangoPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rangos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangoPersonals", x => x.IdRangoPersonal);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    IdPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRangoPersonal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.IdPersonal);
                    table.ForeignKey(
                        name: "FK_Personals_RangoPersonals_IdRangoPersonal",
                        column: x => x.IdRangoPersonal,
                        principalTable: "RangoPersonals",
                        principalColumn: "IdRangoPersonal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RangoPersonals",
                columns: new[] { "IdRangoPersonal", "Rangos" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "Colaborador" }
                });

            migrationBuilder.InsertData(
                table: "Personals",
                columns: new[] { "IdPersonal", "Celular", "Correo", "IdRangoPersonal", "Nombres" },
                values: new object[,]
                {
                    { 1, "78793467", "juan@email.com", 1, "Juan" },
                    { 2, "98873432", "maria@email.com", 2, "María" },
                    { 3, "66341289", "gerardo@email.com", 3, "Gerardo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdRangoPersonal",
                table: "Personals",
                column: "IdRangoPersonal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "RangoPersonals");
        }
    }
}
