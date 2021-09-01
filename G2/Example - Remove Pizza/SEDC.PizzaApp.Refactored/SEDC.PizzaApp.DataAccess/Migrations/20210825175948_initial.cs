using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PizzaSize = table.Column<int>(nullable: false),
                    IsOnPromotion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<int>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    PizzaSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "IsOnPromotion", "Name", "PizzaSize" },
                values: new object[,]
                {
                    { 1, true, "Kaprichioza", 0 },
                    { 2, false, "Pepperoni", 0 },
                    { 3, false, "Margarita", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Address1", "Tanja", "Stojanovska" },
                    { 2, "Address2", "Aleksandar", "Manasiev" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Delivered", "Location", "PaymentMethod", "UserId" },
                values: new object[] { 1, true, "Store1", 2, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Delivered", "Location", "PaymentMethod", "UserId" },
                values: new object[] { 2, false, "Store2", 1, 2 });

            migrationBuilder.InsertData(
                table: "PizzaOrder",
                columns: new[] { "Id", "OrderId", "PizzaId", "PizzaSize" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PizzaOrder",
                columns: new[] { "Id", "OrderId", "PizzaId", "PizzaSize" },
                values: new object[] { 2, 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "PizzaOrder",
                columns: new[] { "Id", "OrderId", "PizzaId", "PizzaSize" },
                values: new object[] { 3, 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_OrderId",
                table: "PizzaOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzaId",
                table: "PizzaOrder",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrder");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
