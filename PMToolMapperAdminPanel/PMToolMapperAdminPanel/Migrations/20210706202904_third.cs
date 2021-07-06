using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMToolMapperAdminPanel.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolFeatures_AllFeatures_AllFeaturesFeatureId",
                table: "ToolFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_ToolFeatures_PMTool_PMToolToolId",
                table: "ToolFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_ToolFeatures_ToolFeatureCategories_ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ToolFeatures_AllFeaturesFeatureId",
                table: "ToolFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ToolFeatures_PMToolToolId",
                table: "ToolFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ToolFeatures_ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures");

            migrationBuilder.DropColumn(
                name: "AllFeaturesFeatureId",
                table: "ToolFeatures");

            migrationBuilder.DropColumn(
                name: "PMToolToolId",
                table: "ToolFeatures");

            migrationBuilder.DropColumn(
                name: "ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures");

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 7, 7, 1, 59, 4, 3, DateTimeKind.Local).AddTicks(2235));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllFeaturesFeatureId",
                table: "ToolFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PMToolToolId",
                table: "ToolFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserLogin",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 7, 6, 1, 38, 46, 118, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_AllFeaturesFeatureId",
                table: "ToolFeatures",
                column: "AllFeaturesFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_PMToolToolId",
                table: "ToolFeatures",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures",
                column: "ToolFeatureCategoriesFeatureCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToolFeatures_AllFeatures_AllFeaturesFeatureId",
                table: "ToolFeatures",
                column: "AllFeaturesFeatureId",
                principalTable: "AllFeatures",
                principalColumn: "FeatureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToolFeatures_PMTool_PMToolToolId",
                table: "ToolFeatures",
                column: "PMToolToolId",
                principalTable: "PMTool",
                principalColumn: "ToolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToolFeatures_ToolFeatureCategories_ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures",
                column: "ToolFeatureCategoriesFeatureCategoryId",
                principalTable: "ToolFeatureCategories",
                principalColumn: "FeatureCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
