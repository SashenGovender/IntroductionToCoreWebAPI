﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackjackData.Migrations
{
    public partial class IntialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerSessionInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    PlayerCards = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSessionInformation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSessionInformation");
        }
    }
}
