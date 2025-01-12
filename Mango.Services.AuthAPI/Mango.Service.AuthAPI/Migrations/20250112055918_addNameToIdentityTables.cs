using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addNameToIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "AspNetUsers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Discriminator");
        }
    }
}
