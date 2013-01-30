using System;
using System.Linq;
using System.Web.Mvc;
using Training.Web.Data;

namespace Training.Web.Controllers
{
    public class EditPersonController : Controller
    {
         public ActionResult Index()
         {
             return View(EntityStore.Current.Personen);
         }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            var person = EntityStore.Current.Personen.SingleOrDefault(p => p.Id == id); 
            if (person == null)
                return new HttpNotFoundResult();
            return View(person);
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}