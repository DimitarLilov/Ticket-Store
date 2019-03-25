namespace TicketStore.Web.Shared.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class CreateEventRequestModel : IMapTo<Event>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string EventDateTime { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateEventRequestModel, Event>()
                .ForMember(x => x.Date,
                    m => m.MapFrom(c => DateTime.Parse(c.EventDateTime)));
        }
    }
}
