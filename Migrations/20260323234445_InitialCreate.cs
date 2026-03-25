using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Musicana.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<int>(type: "int", maxLength: 60, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Genre = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PlayCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Instruments",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Instruments", x => new { x.MusicianId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_Musician_Instruments_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Musician_Instruments_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Musician_Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false),
                    MusicianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Songs", x => new { x.MusicianId, x.SongId });
                    table.ForeignKey(
                        name: "FK_Musician_Songs_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Songs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "Id", "Description", "ImageUrl", "IsDeleted", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Description 1", "/Instruments/Guitar.jpg", false, "Guitar", 0 },
                    { 2, "Description 2", "/Instruments/piano.jpg", false, "Piano", 3 },
                    { 3, "Description 3", "/Instruments/piano.jpg", false, "Piano", 3 },
                    { 4, "Description 4", "/Instruments/piano.jpg", false, "Piano", 3 },
                    { 5, "Description 5", "/Instruments/piano.jpg", false, "Piano", 3 },
                    { 6, "Description 6", "/Instruments/Guitar.jpg", false, "Guitar", 0 }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "Id", "BirthDate", "Genre", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, "John Doe" },
                    { 2, new DateTime(1992, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Jane Smith" },
                    { 3, new DateTime(1985, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, "Bob Johnson" },
                    { 4, new DateTime(1988, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "Alice Brown" },
                    { 5, new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Charlie Davis" },
                    { 6, new DateTime(1991, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Emily Wilson" },
                    { 7, new DateTime(1987, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Michael Taylor" },
                    { 8, new DateTime(1993, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Sarah Miller" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Description", "Duration", "FilePath", "Genre", "IsDeleted", "PlayCount", "Title" },
                values: new object[,]
                {
                    { 1, "Description 1", 0.0, "/Songs/song1.mp3", 1, false, 0, "Song 1" },
                    { 2, "Description 2", 0.0, "/Songs/song1.mp3", 0, false, 0, "Song 2" },
                    { 3, "Description 3", 0.0, "/Songs/song1.mp3", 6, false, 0, "Song 3" },
                    { 4, "Description 4", 0.0, "/Songs/song1.mp3", 4, false, 0, "Song 4" },
                    { 5, "Description 5", 0.0, "/Songs/song1.mp3", 3, false, 0, "Song 5" },
                    { 6, "Description 6", 0.0, "/Songs/song1.mp3", 1, false, 0, "Song 6" },
                    { 7, "Description 7", 0.0, "/Songs/song1.mp3", 4, false, 0, "Song 7" },
                    { 8, "Description 8", 0.0, "/Songs/song1.mp3", 2, false, 0, "Song 8" },
                    { 9, "Description 9", 0.0, "/Songs/song1.mp3", 5, false, 0, "Song 9" },
                    { 10, "Description 10", 0.0, "/Songs/song1.mp3", 1, false, 0, "Song 10" }
                });

            migrationBuilder.InsertData(
                table: "Musician_Instruments",
                columns: new[] { "InstrumentId", "MusicianId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 1, 4 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Musician_Songs",
                columns: new[] { "MusicianId", "SongId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_InstrumentId",
                table: "Musician_Instruments",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Songs_SongId",
                table: "Musician_Songs",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musician_Instruments");

            migrationBuilder.DropTable(
                name: "Musician_Songs");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
