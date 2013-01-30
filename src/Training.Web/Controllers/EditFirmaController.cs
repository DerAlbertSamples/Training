using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Training.Web.Entities;

namespace Training.Web.Controllers
{
    public class EditFirmaController : BaseController
    {
        public ActionResult Index()
        {
            return View(DbContext.Firmen.ToArray());
        }

        public ActionResult Create()
        {
            return View(new Firma());
        }

        [HttpPost]
        public ActionResult Create(Firma model)
        {
            if (!ModelState.IsValid)
                return View(model);

            DbContext.Firmen.Add(model);
            DbContext.SaveChanges();
            return RedirectToAction("Details", new {model.Id});
        }

        Firma FindFirma(int id)
        {
            return DbContext.Firmen.SingleOrDefault(f => f.Id == id);
        }

        Firma FindFirmaComplete(int id)
        {
            return DbContext.Firmen.Include("Abteilungen.Personen").SingleOrDefault(f => f.Id == id);
        }

        public ActionResult Edit(int id)
        {
            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();

            return View(firma);
        }

        [HttpPost]
        public ActionResult Edit(int id, Firma model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();

            UpdateModel(firma);
            DbContext.SaveChanges();
            return RedirectToAction("Details", new {id});
        }

        public ActionResult Details(int id)
        {
            var firma = FindFirmaComplete(id);
            if (firma == null)
                return new HttpNotFoundResult();

            return View(firma);
        }

        public ActionResult Delete(int id)
        {
            var firma = FindFirma(id);
            if (firma == null)
                return new HttpNotFoundResult();

            return View(firma);
        }

        [HttpPost]
        [ActionName("Delete")]
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