using System;
using AutoMapper;
using Training.Web.Entities;
using Training.Web.Models;

namespace Training.Web.Infrastructure.Mappings
{
    public class PersonMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            CreateMap<Person, EditPersonIndexModel>();
            CreateMap<Person, EditPersonDeleteModel>();
            CreateMap<Person, EditPersonDetailsModel>();

            CreateMap<EditPersonCreateModel, Person>()
                .ForMember(d => d.Id, c => c.Ignore())
                .ForMember(d => d.Adresse, c => c.Ignore())
                .ForMember(d => d.Contact, c => c.Ignore());

            CreateMap<EditPersonEditModel, Person>()
                .ForMember(d => d.Id, c => c.Ignore());
            CreateMap<Person, EditPersonEditModel>();
        }
    }
}