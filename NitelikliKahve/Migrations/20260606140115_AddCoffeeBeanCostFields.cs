using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NitelikliKahve.Migrations
{
    /// <inheritdoc />
    public partial class AddCoffeeBeanCostFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Recipes",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "PackageWeight",
                table: "CoffeeBeans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CoffeeBeans",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageWeight",
                table: "CoffeeBeans");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CoffeeBeans");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Recipes",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
