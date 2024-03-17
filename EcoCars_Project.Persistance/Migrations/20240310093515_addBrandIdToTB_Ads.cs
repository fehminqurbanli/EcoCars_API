using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCars_Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addBrandIdToTB_Ads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Brand_Id",
                table: "TB_Ads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand_Id",
                table: "TB_Ads");
        }
    }
}
