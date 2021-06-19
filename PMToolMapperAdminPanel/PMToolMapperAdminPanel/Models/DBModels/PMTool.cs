using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("PMTool")]
    public class PMTool
    {
        [Key]
        public int ToolId { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        public string ToolName { get; set; }
    }
}
