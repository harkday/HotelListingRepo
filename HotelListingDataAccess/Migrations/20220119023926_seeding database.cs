using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListingDataAccess.Migrations
{
    public partial class Seedingdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Shortname",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Shortname" },
                values: new object[] { 1, "Nigeria", "NIG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Shortname" },
                values: new object[] { 2, "Ghana", "GHN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Shortname" },
                values: new object[] { 3, "Cameroon", "CMR" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "rating" },
                values: new object[] { 1, "Maryland", 1, "Sharaton", 4.0 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "rating" },
                values: new object[] { 2, "Victoria Island", 2, "Radisson Blue", 5.0 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "rating" },
                values: new object[] { 3, "Adeniyi Jones", 3, "Chesterfield", 3.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Shortname",
                table: "Countries");
        }
    }
}
