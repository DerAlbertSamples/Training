using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Training.Web.Entities;

namespace Training.Web.Models
{
    public class EditFirmaDetailsModel
    {
        public class AbteilungModel
        {
            public AbteilungModel()
            {
                Personen = new List<PersonModel>();
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<PersonModel> Personen { get; set; }
        }

        public class PersonModel
        {
            public int Id { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }

            public string Vollstaendig
            {
                get { return Nachname+ ", " + Vorname; }
            }
        }

        public EditFirmaDetailsModel()
        {
            Abteilungen = new List<AbteilungModel>();
        }

        public int Id { get; private set; }

        [StringLength(64)]
        [Required]
        public string Name1 { get; set; }

        [StringLength(64)]
        public string Name2 { get; set; }

        public Adresse Adresse { get; set; }
        public Contact Contact { get; set; }
        public virtual IEnumerable<AbteilungModel> Abteilungen { get; set; }
    }
}