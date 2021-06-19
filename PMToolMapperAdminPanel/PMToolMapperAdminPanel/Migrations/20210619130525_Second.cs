﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMToolMapperAdminPanel.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PMTool",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMTool", x => x.ToolId);
                });

            migrationBuilder.CreateTable(
                name: "ToolFeatureCategories",
                columns: table => new
                {
                    FeatureCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureCategoryName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolFeatureCategories", x => x.FeatureCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Paswword = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ToolFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    FeatureCategoryId = table.Column<int>(type: "int", nullable: false),
                    ToolFeatureCategoriesFeatureCategoryId = table.Column<int>(type: "int", nullable: true),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    PMToolToolId = table.Column<int>(type: "int", nullable: true),
                    FeatureStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolFeatures_PMTool_PMToolToolId",
                        column: x => x.PMToolToolId,
                        principalTable: "PMTool",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToolFeatures_ToolFeatureCategories_ToolFeatureCategoriesFeatureCategoryId",
                        column: x => x.ToolFeatureCategoriesFeatureCategoryId,
                        principalTable: "ToolFeatureCategories",
                        principalColumn: "FeatureCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MappingHistory",
                columns: table => new
                {
                    MappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldToolId = table.Column<int>(type: "int", nullable: false),
                    NewToolId = table.Column<int>(type: "int", nullable: false),
                    PMToolToolId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserLoginUserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingHistory", x => x.MappingId);
                    table.ForeignKey(
                        name: "FK_MappingHistory_PMTool_PMToolToolId",
                        column: x => x.PMToolToolId,
                        principalTable: "PMTool",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MappingHistory_UserLogin_UserLoginUserId",
                        column: x => x.UserLoginUserId,
                        principalTable: "UserLogin",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MigrationHistory",
                columns: table => new
                {
                    Migrationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldToolId = table.Column<int>(type: "int", nullable: false),
                    NewToolId = table.Column<int>(type: "int", nullable: false),
                    PMToolToolId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserLoginUserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationHistory", x => x.Migrationid);
                    table.ForeignKey(
                        name: "FK_MigrationHistory_PMTool_PMToolToolId",
                        column: x => x.PMToolToolId,
                        principalTable: "PMTool",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigrationHistory_UserLogin_UserLoginUserId",
                        column: x => x.UserLoginUserId,
                        principalTable: "UserLogin",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MappingHistoryDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MappingId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    ToolFeaturesId = table.Column<int>(type: "int", nullable: true),
                    MappingStatus = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingHistoryDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_MappingHistoryDetail_ToolFeatures_ToolFeaturesId",
                        column: x => x.ToolFeaturesId,
                        principalTable: "ToolFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistory_PMToolToolId",
                table: "MappingHistory",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistory_UserLoginUserId",
                table: "MappingHistory",
                column: "UserLoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistoryDetail_ToolFeaturesId",
                table: "MappingHistoryDetail",
                column: "ToolFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationHistory_PMToolToolId",
                table: "MigrationHistory",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationHistory_UserLoginUserId",
                table: "MigrationHistory",
                column: "UserLoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_PMToolToolId",
                table: "ToolFeatures",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures",
                column: "ToolFeatureCategoriesFeatureCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MappingHistory");

            migrationBuilder.DropTable(
                name: "MappingHistoryDetail");

            migrationBuilder.DropTable(
                name: "MigrationHistory");

            migrationBuilder.DropTable(
                name: "ToolFeatures");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "PMTool");

            migrationBuilder.DropTable(
                name: "ToolFeatureCategories");
        }
    }
}
