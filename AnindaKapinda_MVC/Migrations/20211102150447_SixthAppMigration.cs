using Microsoft.EntityFrameworkCore.Migrations;

namespace AnindaKapinda_MVC.Migrations
{
    public partial class SixthAppMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CartProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "CartProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
