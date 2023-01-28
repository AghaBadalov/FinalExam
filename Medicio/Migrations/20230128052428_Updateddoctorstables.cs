using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicio.Migrations
{
    public partial class Updateddoctorstables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Doctors",
                type: "nvarchar(125)",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Doctors",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(125)",
                oldMaxLength: 125,
                oldNullable: true);
        }
    }
}
