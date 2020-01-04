using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackjackData.Migrations
{
    public partial class updatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerCardIds",
                table: "PlayerSessionInformation",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerCardIds",
                table: "PlayerSessionInformation");
        }
    }
}
