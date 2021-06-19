using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("MigrationHistory")]
    public class MigrationHistory
    {
        [Key]
        public int Migrationid { get; set; }

        public int OldToolId { get; set; }

        public int NewToolId { get; set; }
        public PMTool PMTool { get; set; }

        public int UserId { get; set; }
        public UserLogin UserLogin { get; set; }

        public DateTime Date { get; set; }
    }
}
