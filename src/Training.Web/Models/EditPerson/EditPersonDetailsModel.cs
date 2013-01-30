using System;
using System.ComponentModel.DataAnnotations;
using Training.Web.Entities;

namespace Training.Web.Models
{
    public class EditPersonDetailsModel
    {
        public EditPersonDetailsModel()
        {
            Adresse = new Adresse();
            Contact = new Contact();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Anrede { get; set; }

        [Required]
        [StringLength(64)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(64)]
        public string Nachname { get; set; }

        public Adresse Adresse { get; private set; }
        public Contact Contact { get; private set; }
    }
}