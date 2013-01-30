using System;
using Training.Web.Entities;

namespace Training.Web.Data
{
    public static class DataSeeder
    {
        public static void Seed(EntityStore store)
        {
            store.Add(new Person { Anrede = "Herr", Vorname = "Albert", Nachname = "Weinert"});
            store.Add(new Person { Anrede = "Herr", Vorname = "Peter", Nachname = "Schmitz" });
            store.Add(new Person { Anrede = "Frau", Vorname = "Karoline", Nachname = "Michi" });
            store.Add(new Person { Anrede = "Frau", Vorname = "Justine", Nachname = "Herzig" });
            store.Add(new Person { Anrede = "Herr", Vorname = "Friedhold", Nachname = "Dimond" });
            store.Add(new Person { Anrede = "Frau", Vorname = "Katharina", Nachname = "Ketterman" });
        }
    }
}