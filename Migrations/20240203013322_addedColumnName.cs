using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insti.Migrations
{
    /// <inheritdoc />
    public partial class addedColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "AdminInstitutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "AdminInstitutions");
        }
    }
}
