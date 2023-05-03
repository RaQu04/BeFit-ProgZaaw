using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61883f98-d02c-4d90-b1ef-33a782021141", "AQAAAAEAACcQAAAAENuFuyFphS+72+x3IF36UQTyLmDGUmUEngcOGD5PtuooB3XcpgOxQ58YvyHw7458cg==", "1a2b1f9a-126d-4147-a704-f240d231370b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e13423da-8fb1-4a9c-acfb-174d622f31f1", "AQAAAAEAACcQAAAAEG3/wB7eIDQeN6VYb2n62i5xotAOpeYXD00RGSlfeD4oX9STsXhN5isXK8UD4mEbfA==", "1abfdff2-239d-4033-a052-a24912a27d61" });
        }
    }
}
