using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcmeSistemaServidor.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoCamposTratamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tratamentos",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Tratamentos",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Tratamentos",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Tratamentos",
                newName: "Status");
        }
    }
}
