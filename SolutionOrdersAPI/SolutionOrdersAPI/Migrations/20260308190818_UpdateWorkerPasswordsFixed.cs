using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionOrdersAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkerPasswordsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "IdWorker",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$1VcIIE8UV7jmPX4G8639weyVcM2XKTBhNB.9kSV9hClwdZAZDMlxW");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "IdWorker",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$r9tztql2KWu2d1FMb0.yfuYTJJIA1dNtp5b4oZQWNC84pOfW/7oaG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "IdWorker",
                keyValue: 1,
                column: "Password",
                value: "haslo123");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "IdWorker",
                keyValue: 2,
                column: "Password",
                value: "haslo456");
        }
    }
}
