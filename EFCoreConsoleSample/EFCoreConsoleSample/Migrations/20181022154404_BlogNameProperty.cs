using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreConsoleSample.Migrations
{
    public partial class BlogNameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "varchar(10)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Chris");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blogs");
        }
    }
}
