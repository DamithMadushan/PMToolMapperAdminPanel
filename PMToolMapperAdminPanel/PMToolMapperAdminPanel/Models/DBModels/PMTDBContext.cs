using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    public class PMTDBContext : DbContext 
    {
        public PMTDBContext(DbContextOptions<PMTDBContext> options) : base(options)
        {

        }


        public DbSet<UserLogin> userLogins { get; set; }

        public DbSet<MappingHistory> mappingHistories { get; set; }

        public DbSet<MappingHistoryDetail> mappingHistoryDetails { get; set; }

        public DbSet<MigrationHistory> migrationHistories { get; set; }

        public DbSet<PMTool> pMTools { get; set; }

        public DbSet<ToolFeatureCategories> toolFeatureCategories { get; set; }

        public DbSet<ToolFeatures> toolFeatures { get; set; }

        public DbSet<AllFeatures> allFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserLogin>().HasData(
                new UserLogin { 
                       UserId = 1,
                       UserFullName = "Sam Perera",
                       UserName = "Admin",
                       UserRole = "Admin",
                       Paswword = "1234$",
                       Date = DateTime.Now
                });


            modelBuilder.Entity<MappingHistory>();
            modelBuilder.Entity<MappingHistoryDetail>();
            modelBuilder.Entity<MigrationHistory>();


            modelBuilder.Entity<PMTool>().HasData(
                
                new PMTool
                {
                    ToolId = 1,
                    ToolName = "TFS"
                },
                new PMTool
                {
                    ToolId = 2,
                    ToolName = "Jira"
                });


            modelBuilder.Entity<ToolFeatureCategories>().HasData(
                
                new ToolFeatureCategories
                {
                    FeatureCategoryId = 1,
                    FeatureCategoryName = "Common basic features"
                },
                new ToolFeatureCategories
                {
                    FeatureCategoryId = 2,
                    FeatureCategoryName = "Common advanced features"
                },
                new ToolFeatureCategories
                {
                    FeatureCategoryId = 3,
                    FeatureCategoryName = "Extra features of destination tool"
                });


            modelBuilder.Entity<ToolFeatures>();
            modelBuilder.Entity<AllFeatures>();
        }
    }
}
