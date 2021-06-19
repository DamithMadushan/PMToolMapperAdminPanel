using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels {

    [Table("ToolFeatureCategories")]
    public class ToolFeatureCategories
    {
        [Key]
        public int FeatureCategoryId { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        public string FeatureCategoryName { get; set; }
    }
}
