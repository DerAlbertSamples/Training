using System;
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
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}