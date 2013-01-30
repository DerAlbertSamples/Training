using System.Web.Mvc;
using Training.Web.Infrastructure.ValidatorProviders;

namespace Training.Web.App_Start
{
    public class ValidatorConfig
    {
        public static void Configure(ModelValidatorProviderCollection providers)
        {
            providers.Add(new TrainingModelValidatorProvider());
        }
    }
}