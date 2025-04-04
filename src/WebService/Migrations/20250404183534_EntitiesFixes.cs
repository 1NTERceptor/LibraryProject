using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Loans",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateFrom",
                table: "Loans",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Loans",
                newName: "DateTo");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Loans",
                newName: "DateFrom");
        }
    }
}
