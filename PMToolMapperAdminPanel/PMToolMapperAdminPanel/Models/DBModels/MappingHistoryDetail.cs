using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("MappingHistoryDetail")]
    public class MappingHistoryDetail
    {
        [Key]
        public int DetailId { get; set; }

        public int MappingId { get; set; }


        public int FeatureId { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string MappingStatus { get; set; }
    }
}
