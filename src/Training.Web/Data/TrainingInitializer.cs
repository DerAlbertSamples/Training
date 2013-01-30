using System;
using System.Data.Entity;

namespace Training.Web.Data
{
    public class TrainingInitializer : DropCreateDatabaseIfModelChanges<TrainingContext>
    {
        protected override void Seed(TrainingContext context)
        {
            base.Seed(context);
            DataSeeder.Seed(context);
        }
    }
}