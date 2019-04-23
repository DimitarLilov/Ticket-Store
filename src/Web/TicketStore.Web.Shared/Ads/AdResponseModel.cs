namespace TicketStore.Web.Shared.Ads
{
    using AutoMapper;
    using System;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Events;

    public class AdResponseModel : IMapFrom<Ad>, IHaveCustomMappings
    {
        public EventListItem Event { get; set; }

        public string Type { get; set; }

        public bool Active { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Ad, AdResponseModel>()
                .ForMember(x => x.Type,
                    m => m.MapFrom(c => c.Type.Type));
        }
    }
}
