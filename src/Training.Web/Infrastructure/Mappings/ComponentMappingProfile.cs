using System;
using AutoMapper;
using Training.Web.Entities;

namespace Training.Web.Infrastructure.Mappings
{
    public class ComponentMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            CreateMap<Adresse, Adresse>();
            CreateMap<Contact, Contact>();
        }
    }
}