using System;
using System.Linq;
using System.Web.Http;
using WebServer.Models.DbTables;
using WebServer.Models.Proxies;

namespace WebServer.Controllers
{
    public class DevicesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(db.DEVICES.ToList().Select(x => new DeviceProxy(x)).ToList());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var item = db.DEVICES.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(new DeviceProxy(item));
        }

        [HttpPost]
        public IHttpActionResult Save(DeviceProxy proxy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proxy.Id == 0)
            {
                db.DEVICES.Add(new DEVICES
                {
                    IS_ENABLED = proxy.IsEnabled,
                    MAC_ADDRESS = proxy.MacAddress,
                    STORE = db.STORES.Find(proxy.Store.Id)
                });
            }
            else
            {
                DEVICES row = db.DEVICES.Find(proxy.Id);
                row.IS_ENABLED = proxy.IsEnabled;
                row.MAC_ADDRESS = proxy.MacAddress;
                row.STORE = db.STORES.Find(proxy.Store.Id);
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
            DEVICES item = db.DEVICES.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.DEVICES.Remove(item);
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