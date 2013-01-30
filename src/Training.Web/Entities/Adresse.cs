using System;
using System.ComponentModel.DataAnnotations;

namespace Training.Web.Entities
{
    public class Adresse
    {
        [StringLength(128)]
        public string Straße { get; set; }

        [StringLength(6)]
        public string PLZ { get; set; }

        [StringLength(96)]
        public string Ort { get; set; }
    }
}