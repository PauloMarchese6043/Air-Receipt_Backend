using System;
using System.Linq;
using System.Web.Http;
using WebServer.Models.DbTables;
using WebServer.Models.Proxies;

namespace WebServer.Controllers
{
    public class ReceiptsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(db.RECEIPTS.ToList().Select(x => new ReceiptProxy(x)).ToList());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var item = db.RECEIPTS.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(new ReceiptProxy(item));
        }

        [HttpPost]
        public IHttpActionResult Save(ReceiptProxy proxy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proxy.Id == 0)
            {
                db.RECEIPTS.Add(new RECEIPTS
                {
                    DATE = proxy.Date,
                    FILE = proxy.File,
                    TITLE = proxy.Title,
                    VALUE = proxy.Value,
                    STORE = db.STORES.Find(proxy.Store.Id),
                    USER = db.USERS.Find(proxy.User.Id)
                });
            }
            else
            {
                RECEIPTS row = db.RECEIPTS.Find(proxy.Id);
                row.DATE = proxy.Date;
                row.FILE = proxy.File;
                row.TITLE = proxy.Title;
                row.VALUE = proxy.Value;
                row.STORE = db.STORES.Find(proxy.Store.Id);
                row.USER = db.USERS.Find(proxy.User.Id);
            }

            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.GetBaseException().ToString();
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            RECEIPTS item = db.RECEIPTS.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.RECEIPTS.Remove(item);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
