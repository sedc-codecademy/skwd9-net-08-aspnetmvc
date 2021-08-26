using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Migrations
{
    public partial class Added_Initial_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Temnica" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Kapri", 7.0, 1 },
                    { 2, "Kapri", 8.0, 2 },
                    { 3, "Kapri", 9.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "IsSubscribed" },
                values: new object[] { 1, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName", "Phone", "SubscriptionId" },
                values: new object[] { 1, 1, "Trajan", "Stevkovski", 123432123L, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
