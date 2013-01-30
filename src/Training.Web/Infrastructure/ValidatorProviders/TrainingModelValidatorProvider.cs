using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Training.Web.Entities;

namespace Training.Web.Infrastructure.ValidatorProviders
{
    public class TrainingModelValidatorProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.Model is Adresse)
            {
                yield return new AdresseModelValidator(metadata, context);
            }
        }
    }
}