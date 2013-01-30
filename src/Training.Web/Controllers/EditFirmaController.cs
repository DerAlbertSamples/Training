using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Linq;
using Training.Web.Entities;
using Training.Web.Extensions;
using Training.Web.Models;

namespace Training.Web.Controllers
{
    public class EditFirmaController : BaseController
    {
        public ActionResult Index()
        {
            return View(DbContext.Firmen.Project().ToArray<EditFirmaIndexModel>());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(new EditFirmaCreateModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(EditFirmaCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var firma = model.MapTo<Firma>();
            DbContext.Firmen.Add(firma);
            DbContext.SaveChanges();
            return RedirectToAction("Details", new {firma.Id});
        }

        Firma FindFirma(int id)
        {
            return DbContext.Firmen.SingleOrDefault(f => f.Id == id);
        }

        EditFirmaDetailsModel FindFirmaComplete(int id)
        {
            return
                DbContext.Firmen.Project().To<EditFirmaDetailsModel>()
                         .SingleOrDefault(f => f.Id == id);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();

            return View(firma.MapTo<EditFirmaEditModel>());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, EditFirmaEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();
            model.MapTo(firma);

            DbContext.SaveChanges();
            return RedirectToAction("Details", new {id});
        }

        public ActionResult Details(int id)
        {
            var firma = FindFirmaComplete(id);

            if (firma == null)
                return new HttpNotFoundResult();

            return View(firma.MapTo<EditFirmaDetailsModel>());
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();

            return View(firma.MapTo<EditFirmaDeleteModel>());
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize]
        public ActionResult DeletePost(int id)
        {
            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();

            DbContext.Firmen.Remove(firma);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}