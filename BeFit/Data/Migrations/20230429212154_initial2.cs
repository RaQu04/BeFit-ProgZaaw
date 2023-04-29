using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumOfSesssion",
                table: "Statistic",
                newName: "NumOfSession");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumOfSession",
                table: "Statistic",
                newName: "NumOfSesssion");
        }
    }
}
