using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaTour2021_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Accessibility = table.Column<bool>(type: "boolean", nullable: false),
                    StartingPointLat = table.Column<double>(type: "double precision", nullable: false),
                    StartingPointLng = table.Column<double>(type: "double precision", nullable: false),
                    FinishPointLat = table.Column<double>(type: "double precision", nullable: false),
                    FinishPointLng = table.Column<double>(type: "double precision", nullable: false),
                    creationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PoiType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LocationLat = table.Column<double>(type: "double precision", nullable: false),
                    LocationLng = table.Column<double>(type: "double precision", nullable: false),
                    TrackId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pois_tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pois_TrackId",
                table: "pois",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_Name",
                table: "tracks",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pois");

            migrationBuilder.DropTable(
                name: "tracks");
        }
    }
}
