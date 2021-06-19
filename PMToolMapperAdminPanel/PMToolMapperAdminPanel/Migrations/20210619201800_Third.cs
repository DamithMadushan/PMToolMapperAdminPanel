using Microsoft.EntityFrameworkCore.Migrations;

namespace PMToolMapperAdminPanel.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MappingHistoryDetail_ToolFeatures_ToolFeaturesId",
                table: "MappingHistoryDetail");

            migrationBuilder.DropIndex(
                name: "IX_MappingHistoryDetail_ToolFeaturesId",
                table: "MappingHistoryDetail");

            migrationBuilder.DropColumn(
                name: "ToolFeaturesId",
                table: "MappingHistoryDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToolFeaturesId",
                table: "MappingHistoryDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistoryDetail_ToolFeaturesId",
                table: "MappingHistoryDetail",
                column: "ToolFeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MappingHistoryDetail_ToolFeatures_ToolFeaturesId",
                table: "MappingHistoryDetail",
                column: "ToolFeaturesId",
                principalTable: "ToolFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
