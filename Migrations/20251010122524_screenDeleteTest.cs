using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Migrations
{
    /// <inheritdoc />
    public partial class screenDeleteTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "screen",
                columns: new[] { "Id", "Capacity", "MovieId", "ScreenNumber" },
                values: new object[] { 4, 100, 3, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "screen",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
