using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCars_Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Add_RatingData_Clmns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RatingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RatingStar",
                table: "RatingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "RatingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RatingDatas");

            migrationBuilder.DropColumn(
                name: "RatingStar",
                table: "RatingDatas");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "RatingDatas");
        }
    }
}
