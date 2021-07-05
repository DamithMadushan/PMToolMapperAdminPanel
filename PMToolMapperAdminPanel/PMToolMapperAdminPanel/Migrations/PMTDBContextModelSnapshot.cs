﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMToolMapperAdminPanel.Models.DBModels;

namespace PMToolMapperAdminPanel.Migrations
{
    [DbContext(typeof(PMTDBContext))]
    partial class PMTDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.AllFeatures", b =>
                {
                    b.Property<int>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeatureName")
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("FeatureId");

                    b.ToTable("AllFeatures");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.MappingHistory", b =>
                {
                    b.Property<int>("MappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewToolId")
                        .HasColumnType("int");

                    b.Property<int>("OldToolId")
                        .HasColumnType("int");

                    b.Property<int?>("PMToolToolId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserLoginUserId")
                        .HasColumnType("int");

                    b.HasKey("MappingId");

                    b.HasIndex("PMToolToolId");

                    b.HasIndex("UserLoginUserId");

                    b.ToTable("MappingHistory");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.MappingHistoryDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<int>("MappingId")
                        .HasColumnType("int");

                    b.Property<string>("MappingStatus")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DetailId");

                    b.ToTable("MappingHistoryDetail");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.MigrationHistory", b =>
                {
                    b.Property<int>("Migrationid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewToolId")
                        .HasColumnType("int");

                    b.Property<int>("OldToolId")
                        .HasColumnType("int");

                    b.Property<int?>("PMToolToolId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserLoginUserId")
                        .HasColumnType("int");

                    b.HasKey("Migrationid");

                    b.HasIndex("PMToolToolId");

                    b.HasIndex("UserLoginUserId");

                    b.ToTable("MigrationHistory");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.PMTool", b =>
                {
                    b.Property<int>("ToolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToolName")
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ToolId");

                    b.ToTable("PMTool");

                    b.HasData(
                        new
                        {
                            ToolId = 1,
                            ToolName = "TFS"
                        },
                        new
                        {
                            ToolId = 2,
                            ToolName = "Jira"
                        });
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.ToolFeatureCategories", b =>
                {
                    b.Property<int>("FeatureCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeatureCategoryName")
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("FeatureCategoryId");

                    b.ToTable("ToolFeatureCategories");

                    b.HasData(
                        new
                        {
                            FeatureCategoryId = 1,
                            FeatureCategoryName = "Common basic features"
                        },
                        new
                        {
                            FeatureCategoryId = 2,
                            FeatureCategoryName = "Common advanced features"
                        },
                        new
                        {
                            FeatureCategoryId = 3,
                            FeatureCategoryName = "Extra features of destination tool"
                        });
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.ToolFeatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AllFeaturesFeatureId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FeatureCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("FeatureStatus")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FeatureUrl")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("PMToolToolId")
                        .HasColumnType("int");

                    b.Property<int?>("ToolFeatureCategoriesFeatureCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllFeaturesFeatureId");

                    b.HasIndex("PMToolToolId");

                    b.HasIndex("ToolFeatureCategoriesFeatureCategoryId");

                    b.ToTable("ToolFeatures");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.UserLogin", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Paswword")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserFullName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("UserLogin");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Date = new DateTime(2021, 7, 6, 1, 38, 46, 118, DateTimeKind.Local).AddTicks(8887),
                            Paswword = "1234$",
                            UserFullName = "Sam Perera",
                            UserName = "Admin",
                            UserRole = "Admin"
                        });
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.MappingHistory", b =>
                {
                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.PMTool", "PMTool")
                        .WithMany()
                        .HasForeignKey("PMToolToolId");

                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.UserLogin", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginUserId");

                    b.Navigation("PMTool");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.MigrationHistory", b =>
                {
                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.PMTool", "PMTool")
                        .WithMany()
                        .HasForeignKey("PMToolToolId");

                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.UserLogin", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginUserId");

                    b.Navigation("PMTool");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("PMToolMapperAdminPanel.Models.DBModels.ToolFeatures", b =>
                {
                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.AllFeatures", "AllFeatures")
                        .WithMany()
                        .HasForeignKey("AllFeaturesFeatureId");

                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.PMTool", "PMTool")
                        .WithMany()
                        .HasForeignKey("PMToolToolId");

                    b.HasOne("PMToolMapperAdminPanel.Models.DBModels.ToolFeatureCategories", "ToolFeatureCategories")
                        .WithMany()
                        .HasForeignKey("ToolFeatureCategoriesFeatureCategoryId");

                    b.Navigation("AllFeatures");

                    b.Navigation("PMTool");

                    b.Navigation("ToolFeatureCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
