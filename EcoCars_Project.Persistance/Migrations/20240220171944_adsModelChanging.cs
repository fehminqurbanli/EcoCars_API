using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCars_Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class adsModelChanging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imageData",
                table: "TB_AdsImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageData",
                table: "TB_AdsImages");
        }
    }
}
