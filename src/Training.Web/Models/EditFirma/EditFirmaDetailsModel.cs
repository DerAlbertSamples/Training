using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Training.Web.Entities;

namespace Training.Web.Models
{
    public class EditFirmaDetailsModel
    {
        public int Id { get; private set; }

        [StringLength(64)]
        [Required]
        public string Name1 { get; set; }

        [StringLength(64)]
        public string Name2 { get; set; }

        public Adresse Adresse { get; set; }
        public Contact Contact { get; set; }
        public virtual IEnumerable<Abteilung> Abteilungen { get; private set; }
    }
}