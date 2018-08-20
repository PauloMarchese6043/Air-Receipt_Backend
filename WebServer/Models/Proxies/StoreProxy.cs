using WebServer.Models.DbTables;

namespace WebServer.Models.Proxies
{
    public class StoreProxy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }

        public StoreProxy() { }
        public StoreProxy(STORES store)
        {
            Id = store.ID;
            Name = store.NAME;
            Address = store.ADDRESS;
            Logo = store.LOGO;
        }
    }
}