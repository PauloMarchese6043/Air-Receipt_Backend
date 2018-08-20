using System;
using WebServer.Models.DbTables;

namespace WebServer.Models.Proxies
{
    public class ReceiptProxy
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string File { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public StoreProxy Store { get; set; }
        public UserProxy User { get; set; }

        public ReceiptProxy() { }
        public ReceiptProxy(RECEIPTS receipt)
        {
            Id = receipt.ID;
            Date = receipt.DATE;
            File = receipt.FILE;
            Value = receipt.VALUE;
            Title = receipt.TITLE;
            Store = receipt.STORE != null ? new StoreProxy(receipt.STORE) : null;
            User = receipt.USER != null ? new UserProxy(receipt.USER) : null;
        }
    }
}