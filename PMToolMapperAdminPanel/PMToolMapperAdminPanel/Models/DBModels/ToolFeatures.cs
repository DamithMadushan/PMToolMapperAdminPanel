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

        public int FeatureCategoryId { get; set; }
      
        public int ToolId { get; set; }
     
        [Column(TypeName = "nvarchar(250)")]
        public string FeatureUrl { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string FeatureStatus { get; set; }

        public DateTime Date { get; set; }
    }
}
