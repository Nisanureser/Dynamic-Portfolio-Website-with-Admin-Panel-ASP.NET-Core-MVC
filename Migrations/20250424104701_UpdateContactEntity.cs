using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioUdemy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Contacts",
                newName: "Değer");

            migrationBuilder.RenameColumn(
                name: "Phone2",
                table: "Contacts",
                newName: "Alan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Değer",
                table: "Contacts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Alan",
                table: "Contacts",
                newName: "Phone2");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
