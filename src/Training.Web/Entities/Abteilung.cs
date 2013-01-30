using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Training.Web.Entities
{
    public class Abteilung
    {
        public Abteilung()
        {
            Personen = new Collection<Person>();
            Dokumente = new Collection<Dokument>();
        }

        public int Id { get; private set; }

        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Person> Personen { get; private set; }

        public  virtual ICollection<Dokument> Dokumente { get; private set; }
    }
}