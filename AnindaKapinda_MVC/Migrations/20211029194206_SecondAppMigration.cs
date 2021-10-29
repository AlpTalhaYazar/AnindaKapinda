using Microsoft.EntityFrameworkCore.Migrations;

namespace AnindaKapinda_MVC.Migrations
{
    public partial class SecondAppMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmation",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmation",
                table: "Clients");
        }
    }
}
