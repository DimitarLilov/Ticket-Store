namespace TicketStore.Services.Data
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        public async Task<AdResponseModel> AddAd(CreateAdRequestModel model)
        {
            var ad = Mapper.Map<Ad>(model);
            ad.Type = this.adsTypeRepository.GetById(model.TypeId);
            await this.adsRepository.AddAsync(ad);
            await this.adsRepository.SaveChangesAsync();

            var response = this.adsRepository.All().FirstOrDefault(a => a.Id == ad.Id);

            var t =  Mapper.Map<AdResponseModel>(response);
            return t;
        }

        public bool ContainsAdsType(string type)
        {
            return this.adsTypeRepository.All().FirstOrDefault(a => a.Type == type) != null;
        }

        public IEnumerable<AdResponseModel> GetAdsByType(string type)
        {
            return this.adsRepository.All().Where(a => a.Type.Type == type && a.Active == true).To<AdResponseModel>().ToList();
        }

        public IEnumerable<AdResponseModel> GetAllAds()
        {
            return this.adsRepository.All().Where(a => a.Active == true).To<AdResponseModel>().ToList();
        }
    }
}
