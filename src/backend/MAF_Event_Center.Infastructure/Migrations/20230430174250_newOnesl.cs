using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAF_Event_Center.Infastructure.Migrations
{
    public partial class newOnesl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Events");
        }
    }
}
