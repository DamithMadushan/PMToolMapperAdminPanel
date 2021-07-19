using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMToolMapperAdminPanel.Migrations
{
    public partial class current : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MappingHistory_PMTool_PMToolToolId",
                table: "MappingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MappingHistory_UserLogin_UserLoginUserId",
                table: "MappingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MigrationHistory_PMTool_PMToolToolId",
                table: "MigrationHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MigrationHistory_UserLogin_UserLoginUserId",
                table: "MigrationHistory");

            migrationBuilder.DropIndex(
                name: "IX_MigrationHistory_PMToolToolId",
                table: "MigrationHistory");

            migrationBuilder.DropIndex(
                name: "IX_MigrationHistory_UserLoginUserId",
                table: "MigrationHistory");

            migrationBuilder.DropIndex(
                name: "IX_MappingHistory_PMToolToolId",
                table: "MappingHistory");

            migrationBuilder.DropIndex(
                name: "IX_MappingHistory_UserLoginUserId",
                table: "MappingHistory");

            migrationBuilder.DropColumn(
                name: "PMToolToolId",
                table: "MigrationHistory");

            migrationBuilder.DropColumn(
                name: "UserLoginUserId",
                table: "MigrationHistory");

            migrationBuilder.DropColumn(
                name: "PMToolToolId",
                table: "MappingHistory");

            migrationBuilder.DropColumn(
                name: "UserLoginUserId",
                table: "MappingHistory");

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 7, 19, 0, 24, 22, 761, DateTimeKind.Local).AddTicks(4270));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PMToolToolId",
                table: "MigrationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLoginUserId",
                table: "MigrationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PMToolToolId",
                table: "MappingHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLoginUserId",
                table: "MappingHistory",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 7, 7, 1, 59, 4, 3, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.CreateIndex(
                name: "IX_MigrationHistory_PMToolToolId",
                table: "MigrationHistory",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationHistory_UserLoginUserId",
                table: "MigrationHistory",
                column: "UserLoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistory_PMToolToolId",
                table: "MappingHistory",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistory_UserLoginUserId",
                table: "MappingHistory",
                column: "UserLoginUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MappingHistory_PMTool_PMToolToolId",
                table: "MappingHistory",
                column: "PMToolToolId",
                principalTable: "PMTool",
                principalColumn: "ToolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MappingHistory_UserLogin_UserLoginUserId",
                table: "MappingHistory",
                column: "UserLoginUserId",
                principalTable: "UserLogin",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MigrationHistory_PMTool_PMToolToolId",
                table: "MigrationHistory",
                column: "PMToolToolId",
                principalTable: "PMTool",
                principalColumn: "ToolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MigrationHistory_UserLogin_UserLoginUserId",
                table: "MigrationHistory",
                column: "UserLoginUserId",
                principalTable: "UserLogin",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
