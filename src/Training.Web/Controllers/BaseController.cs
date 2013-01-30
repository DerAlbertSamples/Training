using System;
using System.Web.Mvc;
using Training.Web.Data;

namespace Training.Web.Controllers
{
    public class BaseController : Controller
    {
        readonly Lazy<TrainingContext> dbContext;

        protected BaseController()
        {
            dbContext = new Lazy<TrainingContext>(() => new TrainingContext());
        }

        protected TrainingContext DbContext
        {
            get { return dbContext.Value; }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (dbContext.IsValueCreated)
                dbContext.Value.Dispose();
        }
    }
}