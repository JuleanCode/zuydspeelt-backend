using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZuydSpeelt.Migrations
{
    /// <inheritdoc />
    public partial class seedingsMORE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "shooter" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
