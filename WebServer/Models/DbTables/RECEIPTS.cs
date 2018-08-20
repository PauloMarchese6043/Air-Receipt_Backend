using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Models.DbTables
{
    public class RECEIPTS
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime DATE { get; set; }
        [Required]
        public string FILE { get; set; }

        public decimal VALUE { get; set; }
        public string TITLE { get; set; }

        [ForeignKey("STORE")]
        public int STORE_ID { get; set; }
        [Required]
        public virtual STORES STORE { get; set; }

        [ForeignKey("USER")]
        public int USER_ID { get; set; }
        [Required]
        public virtual USERS USER { get; set; }
    }
}