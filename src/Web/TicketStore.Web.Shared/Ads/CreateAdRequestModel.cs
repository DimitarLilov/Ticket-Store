namespace TicketStore.Web.Shared.Ads
{
    using System;
    using AutoMapper;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class CreateAdRequestModel : IMapTo<Ad>
    {
        public int EventId { get; set; }

        public int TypeId { get; set; }

        public bool Active { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<CreateAdRequestModel, Ad>()
        //        .ForMember(x => x.Type.Id,
        //            m => m.MapFrom(c => c.TypeId));
        //}
    }
}
