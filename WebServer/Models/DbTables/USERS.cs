using System;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Models.DbTables
{
    public class USERS
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public DateTime LAST_UPDATE { get; set; }

        public string PICTURE_URL { get; set; }
    }
}