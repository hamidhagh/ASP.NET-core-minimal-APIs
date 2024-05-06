using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54ad9b1-795d-4bcc-a7cd-704aabf50b6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e9155b-c96e-4967-8497-a28bfac59cf3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1971182b-2e9b-46a6-8519-ee0ab171da50", null, "User", "USER" },
                    { "f8512404-4e3a-4f94-932d-06b006a0dc6a", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1971182b-2e9b-46a6-8519-ee0ab171da50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8512404-4e3a-4f94-932d-06b006a0dc6a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b54ad9b1-795d-4bcc-a7cd-704aabf50b6a", null, "User", "USER" },
                    { "e8e9155b-c96e-4967-8497-a28bfac59cf3", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
