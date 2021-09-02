using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.
            migrationBuilder.Sql("INSERT INTO dbo.Users (FirstName, LastName, Address, Phone) VALUES('Martin2','Jankuloski2', 'Address2', '123456')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
