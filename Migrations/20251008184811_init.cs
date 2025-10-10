using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTheater.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customerProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customerProfile_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    actorsId = table.Column<int>(type: "int", nullable: false),
                    moviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.actorsId, x.moviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_actor_actorsId",
                        column: x => x.actorsId,
                        principalTable: "actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_movie_moviesId",
                        column: x => x.moviesId,
                        principalTable: "movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "screen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ScreenNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_screen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_screen_movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movie",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScreenId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_booking_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_booking_screen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "screen",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "actor",
                columns: new[] { "Id", "Age", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, 35, "John Carter", "American" },
                    { 2, 29, "Emma Johnson", "British" },
                    { 3, 41, "Kenji Tanaka", "Japanese" },
                    { 4, 32, "Sophia Rossi", "Italian" }
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "adel@example.com", "Adel Mostafa", "+201234567890" },
                    { 2, "mona@example.com", "Mona Youssef", "+201109876543" }
                });

            migrationBuilder.InsertData(
                table: "customerProfile",
                columns: new[] { "Id", "Address", "CustomerId", "DateOfBirth" },
                values: new object[,]
                {
                    { 1, "123 Nile Street, Cairo", null, new DateTime(2005, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "45 Tahrir Square, Giza", null, new DateTime(1998, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "movie",
                columns: new[] { "Id", "Description", "Duration", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "An epic tale of courage and loyalty.", 145, 8.7m, new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last Kingdom" },
                    { 2, "A sci-fi journey beyond imagination.", 132, 9.1m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Galactic Odyssey" },
                    { 3, "A thrilling mystery in a quiet town.", 118, 7.9m, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silent Whispers" }
                });

            migrationBuilder.InsertData(
                table: "screen",
                columns: new[] { "Id", "Capacity", "MovieId", "ScreenNumber" },
                values: new object[,]
                {
                    { 1, 120, null, 1 },
                    { 2, 80, null, 2 },
                    { 3, 150, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "booking",
                columns: new[] { "Id", "BookingDate", "CustomerId", "ScreenId", "SeatNumber", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 15, "Confirmed" },
                    { 2, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 42, "Pending" },
                    { 3, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_moviesId",
                table: "ActorMovie",
                column: "moviesId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_CustomerId",
                table: "booking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_ScreenId",
                table: "booking",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_customerProfile_CustomerId",
                table: "customerProfile",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movie_Title",
                table: "movie",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_screen_MovieId",
                table: "screen",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_screen_ScreenNumber",
                table: "screen",
                column: "ScreenNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "customerProfile");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "screen");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "movie");
        }
    }
}
