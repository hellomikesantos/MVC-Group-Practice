using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group_Practice.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie-Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Movie-Actor_Actor",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movie-Actor_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movie-Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Movie-Genre_Genre",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movie-Genre_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie-Actor_ActorId",
                table: "Movie-Actor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie-Actor_MovieId",
                table: "Movie-Actor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie-Genre_GenreId",
                table: "Movie-Genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie-Genre_MovieId",
                table: "Movie-Genre",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie-Actor");

            migrationBuilder.DropTable(
                name: "Movie-Genre");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
