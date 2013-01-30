using System;
using Training.Web.Entities;

namespace Training.Web.Data
{
    public static class DataSeeder
    {
        public static void Seed(TrainingContext context)
        {
            var firma = new Firma() { Name1 = "Beste Software AG" };
            context.Firmen.Add(firma);

            var abteilung = new Abteilung() { Name = "IT" };
            firma.Abteilungen.Add(abteilung);
            abteilung.Personen.Add(new Person { Anrede = "Herr", Vorname = "Albert", Nachname = "Weinert" });
            abteilung.Personen.Add(new Person { Anrede = "Herr", Vorname = "Peter", Nachname = "Schmitz" });

            abteilung = new Abteilung() { Name = "Service" };
            firma.Abteilungen.Add(abteilung);
            abteilung.Personen.Add(new Person { Anrede = "Frau", Vorname = "Karoline", Nachname = "Michi" });
            abteilung.Personen.Add(new Person { Anrede = "Frau", Vorname = "Justine", Nachname = "Herzig" });

            firma = new Firma() { Name1 = "Insel Reisen e.K." };
            context.Firmen.Add(firma);

            abteilung = new Abteilung() { Name = "Beratung" };
            firma.Abteilungen.Add(abteilung);
            abteilung.Personen.Add(new Person { Anrede = "Herr", Vorname = "Friedhold", Nachname = "Dimond" });
            abteilung.Personen.Add(new Person { Anrede = "Frau", Vorname = "Katharina", Nachname = "Ketterman" });

        }
    }
}