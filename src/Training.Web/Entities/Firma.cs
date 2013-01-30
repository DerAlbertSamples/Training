using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Training.Web.Entities
{
    public class Firma
    {
        public Firma()
        {
            Abteilungen = new Collection<Abteilung>();
            Adresse = new Adresse();
            Contact = new Contact();
        }

        public int Id { get; private set; }

        [StringLength(64)]
        [Required]
        public string Name1 { get; set; }

        [StringLength(64)]
        public string Name2 { get; set; }

        public Adresse Adresse { get; set; }
        public Contact Contact { get; set; }
        public virtual ICollection<Abteilung> Abteilungen { get; private set; }
    }
}