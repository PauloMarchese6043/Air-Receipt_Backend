using WebServer.Models.DbTables;

namespace WebServer.Models.Proxies
{
    public class DeviceProxy
    {
        public int Id { get; set; }
        public bool IsEnabled { get; set; }
        public string MacAddress { get; set; }
        public StoreProxy Store { get; set; }

        public DeviceProxy() { }
        public DeviceProxy(DEVICES device)
        {
            Id = device.ID;
            IsEnabled = device.IS_ENABLED;
            MacAddress = device.MAC_ADDRESS;
            Store = device.STORE != null ? new StoreProxy(device.STORE) : null;
        }
    }
}