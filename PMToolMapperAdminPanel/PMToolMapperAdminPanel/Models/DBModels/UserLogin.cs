using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMToolMapperAdminPanel.Models.DBModels
{
    [Table("UserLogin")]
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName ="nvarchar(200)")]
        public string UserFullName  { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Paswword { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserRole { get; set; }

        public DateTime Date { get; set; }
    }
}
