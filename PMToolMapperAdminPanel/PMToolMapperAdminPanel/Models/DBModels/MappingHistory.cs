using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("MappingHistory")]
    public class MappingHistory
    {
        [Key]
        public int MappingId { get; set; }

        public int OldToolId { get; set; }

        public int NewToolId { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
