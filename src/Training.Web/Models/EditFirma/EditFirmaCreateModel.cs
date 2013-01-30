using System;
using System.ComponentModel.DataAnnotations;

namespace Training.Web.Models
{
    public class EditFirmaCreateModel
    {
        [StringLength(64)]
        [Required]
        public string Name1 { get; set; }

        [StringLength(64)]
        public string Name2 { get; set; }
    }
}