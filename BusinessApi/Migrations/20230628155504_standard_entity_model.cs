using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessApi.Migrations
{
    /// <inheritdoc />
    public partial class standard_entity_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "string");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Id",
                table: "Products",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
