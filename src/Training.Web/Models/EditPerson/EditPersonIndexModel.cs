using System;
using System.ComponentModel.DataAnnotations;

namespace Training.Web.Models
{
    public class EditPersonIndexModel
    {
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
    }
}