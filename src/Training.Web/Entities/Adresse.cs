using System;
using System.Collections.Generic;
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NotValid())
            {
                yield return
                    new ValidationResult(
                        string.Format("Die {0} muss vollständig eingegeben werden", validationContext.DisplayName),
                        new[] {"Straße", "PLZ", "Ort"});
            }
        }

        bool NotValid()
        {
            var count = 0;
            if (!string.IsNullOrWhiteSpace(Straße))
                count++;

            if (!string.IsNullOrWhiteSpace(PLZ))
                count++;

            if (!string.IsNullOrWhiteSpace(Ort))
                count++;

            return count > 0 && count < 3;
        }
    }
}