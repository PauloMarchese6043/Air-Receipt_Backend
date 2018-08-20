using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Models.DbTables
{
    public class DEVICES
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public bool IS_ENABLED { get; set; }
        [Required]
        public string MAC_ADDRESS { get; set; }

        [ForeignKey("STORE")]
        public int STORE_ID { get; set; }
        [Required]
        public virtual STORES STORE { get; set; }
    }
}