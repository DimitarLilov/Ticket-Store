namespace TicketStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Ads;

    public class AdsService : IAdsService
    {
        private readonly IRepository<Ad> adsRepository;
        private readonly IRepository<AdType> adsTypeRepository;

        public AdsService(IRepository<Ad> adsRepository, IRepository<AdType> adsTypeRepository)
        {
            this.adsRepository = adsRepository;
            this.adsTypeRepository = adsTypeRepository;
        }

        public bool ContainsAdsType(string type)
        {
            return this.adsTypeRepository.All().FirstOrDefault(a => a.Type == type) != null;
        }

        public IEnumerable<AdResponseModel> GetAdsByType(string type)
        {
            return this.adsRepository.All().Where(a => a.Type.Type == type).To<AdResponseModel>();
        }

        public IEnumerable<AdResponseModel> GetAllAds()
        {
            return this.adsRepository.All().To<AdResponseModel>();
        }
    }
}
