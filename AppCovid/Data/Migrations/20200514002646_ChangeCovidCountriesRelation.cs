using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCovid.Data.Migrations
{
    public partial class ChangeCovidCountriesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Covids_CovidId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CovidId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CovidId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Covids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Covids_CountryId",
                table: "Covids",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Covids_Countries_CountryId",
                table: "Covids",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covids_Countries_CountryId",
                table: "Covids");

            migrationBuilder.DropIndex(
                name: "IX_Covids_CountryId",
                table: "Covids");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Covids");

            migrationBuilder.AddColumn<int>(
                name: "CovidId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CovidId",
                table: "Countries",
                column: "CovidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Covids_CovidId",
                table: "Countries",
                column: "CovidId",
                principalTable: "Covids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
