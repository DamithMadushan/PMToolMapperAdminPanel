using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("AllFeatures")]
    public class AllFeatures
    {
        [Key]
        public int FeatureId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string FeatureName { get; set; }
    }
}
