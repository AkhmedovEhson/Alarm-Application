using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class User_Alarms_OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Alarms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_UserEntityId",
                table: "Alarms",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_Users_UserEntityId",
                table: "Alarms",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_Users_UserEntityId",
                table: "Alarms");

            migrationBuilder.DropIndex(
                name: "IX_Alarms_UserEntityId",
                table: "Alarms");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Alarms");
        }
    }
}
