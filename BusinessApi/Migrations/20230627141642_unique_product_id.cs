using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessApi.Migrations
{
    /// <inheritdoc />
    public partial class unique_product_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Id",
                table: "Products",
                type: "string",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "string")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
