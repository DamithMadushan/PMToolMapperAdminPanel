using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("ToolFeatures")]
    public class ToolFeatures
    {
        public int Id { get; set; }


        public int FeatureId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string FeatureName { get; set; }


        public int FeatureCategoryId { get; set; }
        public ToolFeatureCategories ToolFeatureCategories { get; set; }

        public int ToolId { get; set; }
        public PMTool PMTool { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string FeatureStatus { get; set; }

        public DateTime Date { get; set; }
    }
}
