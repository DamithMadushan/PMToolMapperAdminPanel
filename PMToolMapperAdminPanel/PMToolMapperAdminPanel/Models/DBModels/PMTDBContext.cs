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

    }
}
