using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NmhNetAssignment.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixedMigration_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Articles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SiteId",
                table: "Articles",
                type: "bigint",
                nullable: true);
        }
    }
}
