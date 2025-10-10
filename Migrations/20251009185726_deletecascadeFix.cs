using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Migrations
{
    /// <inheritdoc />
    public partial class deletecascadeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_customer_CustomerId",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_customerProfile_customer_CustomerId",
                table: "customerProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_customer_CustomerId",
                table: "booking",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customerProfile_customer_CustomerId",
                table: "customerProfile",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_customer_CustomerId",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_customerProfile_customer_CustomerId",
                table: "customerProfile");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_customer_CustomerId",
                table: "booking",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_customerProfile_customer_CustomerId",
                table: "customerProfile",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id");
        }
    }
}
