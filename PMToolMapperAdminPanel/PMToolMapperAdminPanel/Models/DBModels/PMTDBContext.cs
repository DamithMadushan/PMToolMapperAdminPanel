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

            modelBuilder.Entity<UserLogin>();
            modelBuilder.Entity<MappingHistory>();
            modelBuilder.Entity<MappingHistoryDetail>();
            modelBuilder.Entity<MigrationHistory>();
            modelBuilder.Entity<PMTool>();
            modelBuilder.Entity<ToolFeatureCategories>();
            modelBuilder.Entity<ToolFeatures>();
            modelBuilder.Entity<AllFeatures>();
        }
    }
}
