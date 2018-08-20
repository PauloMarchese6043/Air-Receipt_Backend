using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models.DbTables;
using WebServer.Models.Proxies;

namespace WebServer.Controllers
{
    public class DeviceUsesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(db.DEVICE_USES.ToList().Select(x => new DeviceUseProxy(x)).ToList());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var item = db.DEVICE_USES.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(new DeviceUseProxy(item));
        }

        [HttpPost]
        public IHttpActionResult Save(DeviceUseProxy proxy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proxy.Id == 0)
            {
                db.DEVICE_USES.Add(new DEVICE_USES
                {
                    DEVICE = db.DEVICES.Find(proxy.Device.Id),
                    RECEIPT = db.RECEIPTS.Find(proxy.Receipt.Id)
                });
            }
            else
            {
                DEVICE_USES row = db.DEVICE_USES.Find(proxy.Id);
                row.DEVICE = db.DEVICES.Find(proxy.Device.Id);
                row.RECEIPT = db.RECEIPTS.Find(proxy.Receipt.Id);
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
            DEVICE_USES item = db.DEVICE_USES.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.DEVICE_USES.Remove(item);
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
