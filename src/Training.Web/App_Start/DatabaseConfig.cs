using System.Data.Entity;
using Training.Web.Data;

namespace Training.Web.App_Start
{
    public class DatabaseConfig
    {
         public static void Configure()
         {
             Database.SetInitializer(new TrainingInitializer());
         }
    }
}