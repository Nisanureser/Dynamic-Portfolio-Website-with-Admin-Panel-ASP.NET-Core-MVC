using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioUdemy.Migrations
{
    /// <inheritdoc />
    public partial class socialmedia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Socialmedia",
                table: "SocialMedias",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SocialMedias");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SocialMedias",
                newName: "Socialmedia");
        }
    }
}
