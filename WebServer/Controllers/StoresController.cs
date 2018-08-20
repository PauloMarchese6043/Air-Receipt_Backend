using System;
using System.Linq;
using System.Web.Http;
using WebServer.Models.DbTables;
using WebServer.Models.Proxies;

namespace WebServer.Controllers
{
    public class StoresController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(db.STORES.ToList().Select(x => new StoreProxy(x)).ToList());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var item = db.STORES.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(new StoreProxy(item));
        }

        [HttpPost]
        public IHttpActionResult Save(StoreProxy proxy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proxy.Id == 0)
            {
                db.STORES.Add(new STORES
                {
                    ADDRESS = proxy.Address,
                    LOGO = proxy.Logo,
                    NAME = proxy.Name
                });
            }
            else
            {
                STORES row = db.STORES.Find(proxy.Id);
                row.ADDRESS = proxy.Address;
                row.LOGO = proxy.Logo;
                row.NAME = proxy.Name;
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
            STORES item = db.STORES.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.STORES.Remove(item);
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
