﻿using System;
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

        public ActionResult Create()
        {
            return View(new EditPersonCreateModel());
        }

        [HttpPost]
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

        public ActionResult Edit(int id)
        {
            var person = FindPerson(id).MapTo<EditPersonEditModel>();
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditPersonEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var person = FindPerson(id);
            if (person == null)
                return new HttpNotFoundResult();

            person.Anrede = model.Anrede;
            person.Vorname = model.Vorname;
            person.Nachname = model.Nachname;
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

        public ActionResult Delete(int id)
        {
            var person = FindPerson(id).MapTo<EditPersonDeleteModel>();
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

            DbContext.Personen.Remove(person);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}