using System;
using System.Linq;
using System.Web.Mvc;
using Training.Web.Data;
using Training.Web.Entities;
using Training.Web.Models;
using Training.Web.Extensions;

namespace Training.Web.Controllers
{
    public class EditPersonController : BaseController
    {
        public ActionResult Index(string property = null, string direction = "asc")
        {
            var personen = DbContext.Personen.AsQueryable();

            switch (property)
            {
                case "Anrede":
                    personen = personen.Order(p => p.Anrede, direction);
                    break;
                case "Vorname":
                    personen = personen.Order(p => p.Vorname, direction);
                    break;
                case "Nachname":
                    personen = personen.Order(p => p.Nachname, direction);
                    break;
            }
            return View(personen.ToArray());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(new EditPersonCreateModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(EditPersonCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var person = model.MapTo<Person>();
            DbContext.Personen.Add(person);
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        Person FindPerson(int id)
        {
            return DbContext.Personen.SingleOrDefault(p => p.Id == id);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var person = FindPerson(id).MapTo<EditPersonEditModel>();
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, EditPersonEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();

            model.MapTo(person);

            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var person = FindPerson(id).MapTo<EditPersonDetailsModel>();
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var person = FindPerson(id).MapTo<EditPersonDeleteModel>();
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize]
        public ActionResult DeletePost(int id)
        {
            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();

            DbContext.Personen.Remove(person);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}