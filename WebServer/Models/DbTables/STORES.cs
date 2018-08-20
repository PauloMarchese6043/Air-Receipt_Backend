using System.ComponentModel.DataAnnotations;

namespace WebServer.Models.DbTables
{
    public class STORES
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string ADDRESS { get; set; }

        public string LOGO { get; set; }
    }
}