using System;
using AutoMapper;
using Training.Web.Entities;
using Training.Web.Models;

namespace Training.Web.Infrastructure.Mappings
{
    public class FirmaMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            CreateMap<Firma, EditFirmaIndexModel>();
            CreateMap<Firma, EditFirmaDeleteModel>();
            CreateMap<Firma, EditFirmaDetailsModel>();

            CreateMap<Abteilung, EditFirmaDetailsModel.AbteilungModel>();
            CreateMap<Person, EditFirmaDetailsModel.PersonModel>()
                .ForMember(d => d.Vollstaendig, c => c.Ignore());

            CreateMap<EditFirmaCreateModel, Firma>()
                .ForMember(d => d.Id, c => c.Ignore())
                .ForMember(d => d.Adresse, c => c.Ignore())
                .ForMember(d => d.Contact, c => c.Ignore())
                .ForMember(d => d.Abteilungen, c => c.Ignore());

            CreateMap<EditFirmaEditModel, Firma>()
                .ForMember(d => d.Id, c => c.Ignore())
                .ForMember(d => d.Abteilungen, c => c.Ignore());

            CreateMap<Firma, EditFirmaEditModel>();
        }
    }
}