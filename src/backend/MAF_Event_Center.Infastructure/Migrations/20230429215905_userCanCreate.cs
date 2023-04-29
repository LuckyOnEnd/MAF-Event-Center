using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAF_Event_Center.Infastructure.Migrations
{
    public partial class userCanCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanCreate",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanCreate",
                table: "AspNetUsers");
        }
    }
}
