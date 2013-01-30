using System;
using System.Linq;
using AutoMapper;

namespace Training.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            var profileTypes =
                typeof (AutoMapperConfig).Assembly.GetExportedTypes()
                                         .Where(t => typeof (Profile).IsAssignableFrom(t));

            foreach (var profileType in profileTypes)
            {
                Mapper.AddProfile((Profile) Activator.CreateInstance(profileType));
            }

            Mapper.AssertConfigurationIsValid();
        }
    }
}