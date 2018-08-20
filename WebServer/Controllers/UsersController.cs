using System;
using System.Linq;
using System.Web.Http;
using WebServer.Models.DbTables;
using WebServer.Models.Proxies;

namespace WebServer.Controllers
{
    public class UsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(db.USERS.ToList().Select(x => new UserProxy(x)).ToList());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var item = db.USERS.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(new UserProxy(item));
        }

        [HttpPost]
        public IHttpActionResult Save(UserProxy proxy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (proxy.Id == 0)
            {
                db.USERS.Add(new USERS
                {
                    EMAIL = proxy.Email,
                    LAST_UPDATE = DateTime.Now,
                    PICTURE_URL = proxy.PictureUrl,
                    NAME = proxy.Name
                });
            }
            else
            {
                USERS row = db.USERS.Find(proxy.Id);
                row.EMAIL = proxy.Email;
                row.LAST_UPDATE = DateTime.Now;
                row.PICTURE_URL = proxy.PictureUrl;
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
            USERS item = db.USERS.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.USERS.Remove(item);
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
