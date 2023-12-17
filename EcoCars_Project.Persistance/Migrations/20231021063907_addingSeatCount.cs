using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCars_Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingSeatCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barter",
                table: "TB_Ads");

            migrationBuilder.DropColumn(
                name: "Credit_Have",
                table: "TB_Ads");

            migrationBuilder.AddColumn<int>(
                name: "seat_count",
                table: "TB_Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seat_count",
                table: "TB_Ads");

            migrationBuilder.AddColumn<bool>(
                name: "Barter",
                table: "TB_Ads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Credit_Have",
                table: "TB_Ads",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
