using WebServer.Models.DbTables;

namespace WebServer.Models.Proxies
{
    public class DeviceUseProxy
    {
        public int Id { get; set; }
        public DeviceProxy Device { get; set; }
        public ReceiptProxy Receipt { get; set; }

        public DeviceUseProxy() { }
        public DeviceUseProxy(DEVICE_USES deviceUse)
        {
            Id = deviceUse.ID;
            Device = deviceUse.DEVICE != null ? new DeviceProxy(deviceUse.DEVICE) : null;
            Receipt = deviceUse.RECEIPT != null ? new ReceiptProxy(deviceUse.RECEIPT) : null;
        }
    }
}