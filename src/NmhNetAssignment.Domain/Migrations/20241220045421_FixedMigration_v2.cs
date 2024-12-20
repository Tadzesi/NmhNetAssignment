using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NmhNetAssignment.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixedMigration_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthor_Articles_ArticleId",
                table: "ArticleAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthor_Authors_AuthorsId",
                table: "ArticleAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sites_SiteId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Authors_Id",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Articles_SiteId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleAuthor",
                table: "ArticleAuthor");

            migrationBuilder.RenameTable(
                name: "ArticleAuthor",
                newName: "ArticleAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleAuthor_AuthorsId",
                table: "ArticleAuthors",
                newName: "IX_ArticleAuthors_AuthorsId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Images",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Articles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleAuthors",
                table: "ArticleAuthors",
                columns: new[] { "ArticleId", "AuthorsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthors_Articles_ArticleId",
                table: "ArticleAuthors",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthors_Authors_AuthorsId",
                table: "ArticleAuthors",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sites_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Images_Id",
                table: "Authors",
                column: "Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthors_Articles_ArticleId",
                table: "ArticleAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthors_Authors_AuthorsId",
                table: "ArticleAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sites_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Images_Id",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleAuthors",
                table: "ArticleAuthors");

            migrationBuilder.RenameTable(
                name: "ArticleAuthors",
                newName: "ArticleAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleAuthors_AuthorsId",
                table: "ArticleAuthor",
                newName: "IX_ArticleAuthor_AuthorsId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Images",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Articles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleAuthor",
                table: "ArticleAuthor",
                columns: new[] { "ArticleId", "AuthorsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SiteId",
                table: "Articles",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthor_Articles_ArticleId",
                table: "ArticleAuthor",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthor_Authors_AuthorsId",
                table: "ArticleAuthor",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sites_SiteId",
                table: "Articles",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Authors_Id",
                table: "Images",
                column: "Id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
