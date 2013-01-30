using System;
using System.Linq;
using System.Web.Mvc;
using Training.Web.Data;
using Training.Web.Entities;

namespace Training.Web.Controllers
{
    public class EditPersonController : Controller
    {
        readonly TrainingContext context = new TrainingContext();

        public ActionResult Index(string property = null, string direction = "asc")
        {
            var personen = context.Personen.AsQueryable();

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
            return View(personen);
        }

        public ActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
                return View(person);

            context.Personen.Add(person);
            return RedirectToAction("Index");
        }


        Person FindPerson(int id)
        {
            return context.Personen.SingleOrDefault(p => p.Id == id);
        }

        public ActionResult Edit(int id)
        {
            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(int id, Person model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();

            person.Anrede = model.Anrede;
            person.Vorname = model.Vorname;
            person.Nachname = model.Nachname;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        public ActionResult Delete(int id)
        {
            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();

            context.Personen.Remove(person);
            return RedirectToAction("Index");
        }
    }
}