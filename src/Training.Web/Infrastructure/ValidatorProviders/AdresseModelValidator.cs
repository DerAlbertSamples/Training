using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Training.Web.Entities;

namespace Training.Web.Infrastructure.ValidatorProviders
{
    public class AdresseModelValidator : ModelValidator
    {
        readonly ModelMetadata metadata;

        public AdresseModelValidator(ModelMetadata metadata, ControllerContext controllerContext)
            : base(metadata, controllerContext)
        {
            this.metadata = metadata;
        }

        bool NotValid(Adresse adresse)
        {
            var count = 0;
            if (!string.IsNullOrWhiteSpace(adresse.Straße))
                count++;

            if (!string.IsNullOrWhiteSpace(adresse.PLZ))
                count++;

            if (!string.IsNullOrWhiteSpace(adresse.Ort))
                count++;

            return count > 0 && count < 3;
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            var adresse = (Adresse) metadata.Model;
            if (NotValid(adresse))
            {
                yield return
                    new ModelValidationResult()
                        {
                            MemberName = "Straße",
                            Message = "Die Adresse muss vollständig eingegeben werden"
                        };
                yield return
                    new ModelValidationResult()
                        {
                            MemberName = "PLZ",
                            Message = "Die Adresse muss vollständig eingegeben werden"
                        };
                yield return
                    new ModelValidationResult()
                        {
                            MemberName = "Ort",
                            Message = "Die Adresse muss vollständig eingegeben werden"
                        };
            }
        }
    }
}