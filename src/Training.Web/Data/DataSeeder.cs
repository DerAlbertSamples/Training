using System;
using Training.Web.Entities;

namespace Training.Web.Data
{
    public static class DataSeeder
    {
        public static void Seed(TrainingContext context)
        {
            context.Personen.Add(new Person {Anrede = "Herr", Vorname = "Albert", Nachname = "Weinert"});
            context.Personen.Add(new Person {Anrede = "Herr", Vorname = "Peter", Nachname = "Schmitz"});
            context.Personen.Add(new Person {Anrede = "Frau", Vorname = "Karoline", Nachname = "Michi"});
            context.Personen.Add(new Person {Anrede = "Frau", Vorname = "Justine", Nachname = "Herzig"});
            context.Personen.Add(new Person {Anrede = "Herr", Vorname = "Friedhold", Nachname = "Dimond"});
            context.Personen.Add(new Person {Anrede = "Frau", Vorname = "Katharina", Nachname = "Ketterman"});
        }
    }
}