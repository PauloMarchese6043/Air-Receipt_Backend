using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Models.DbTables
{
    public class DEVICE_USES
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("DEVICE")]
        public int DEVICE_ID { get; set; }
        [Required]
        public virtual DEVICES DEVICE { get; set; }

        [ForeignKey("RECEIPT")]
        public int RECEIPT_ID { get; set; }
        [Required]
        public virtual RECEIPTS RECEIPT { get; set; }
    }
}