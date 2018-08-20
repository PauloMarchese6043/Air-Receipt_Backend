using System;
using WebServer.Models.DbTables;

namespace WebServer.Models.Proxies
{
    public class UserProxy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }
        public string PictureUrl { get; set; }

        public UserProxy() { }
        public UserProxy(USERS user)
        {
            Id = user.ID;
            Name = user.NAME;
            Email = user.EMAIL;
            LastUpdate = user.LAST_UPDATE;
            PictureUrl = user.PICTURE_URL;
        }
    }
}