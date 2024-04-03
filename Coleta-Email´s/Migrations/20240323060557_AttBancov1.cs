using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coleta_Email_s.Migrations
{
    /// <inheritdoc />
    public partial class AttBancov1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimaAtualizacao",
                table: "Emails",
                newName: "DataDeRegistro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeRegistro",
                table: "Emails",
                newName: "UltimaAtualizacao");
        }
    }
}
