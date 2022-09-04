using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    public partial class addedUserToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "BankAccount",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_PersonId",
                table: "BankAccount",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AspNetUsers_PersonId",
                table: "BankAccount",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AspNetUsers_PersonId",
                table: "BankAccount");

            migrationBuilder.DropIndex(
                name: "IX_BankAccount_PersonId",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
