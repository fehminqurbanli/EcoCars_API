using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCars_Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingDistanceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_AdsImages_TB_Ads_Ads_Id",
                table: "TB_AdsImages");

            migrationBuilder.DropIndex(
                name: "IX_TB_AdsImages_Ads_Id",
                table: "TB_AdsImages");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "TB_Ads",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_Ads",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "TB_Ads",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "TB_Ads",
                newName: "city");

            migrationBuilder.AddColumn<Guid>(
                name: "TB_AdsId",
                table: "TB_AdsImages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Distance_Id",
                table: "TB_Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_AdsImages_TB_AdsId",
                table: "TB_AdsImages",
                column: "TB_AdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_AdsImages_TB_Ads_TB_AdsId",
                table: "TB_AdsImages",
                column: "TB_AdsId",
                principalTable: "TB_Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_AdsImages_TB_Ads_TB_AdsId",
                table: "TB_AdsImages");

            migrationBuilder.DropIndex(
                name: "IX_TB_AdsImages_TB_AdsId",
                table: "TB_AdsImages");

            migrationBuilder.DropColumn(
                name: "TB_AdsId",
                table: "TB_AdsImages");

            migrationBuilder.DropColumn(
                name: "Distance_Id",
                table: "TB_Ads");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "TB_Ads",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TB_Ads",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "TB_Ads",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "TB_Ads",
                newName: "City");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AdsImages_Ads_Id",
                table: "TB_AdsImages",
                column: "Ads_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_AdsImages_TB_Ads_Ads_Id",
                table: "TB_AdsImages",
                column: "Ads_Id",
                principalTable: "TB_Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
