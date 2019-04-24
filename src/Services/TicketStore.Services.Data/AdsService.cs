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

            return Mapper.Map<AdResponseModel>(response);
        }

        public async Task<AdResponseModel> EditAd(int id, EditAdRequestModel model)
        {
            var editModel = Mapper.Map<Ad>(model);
            editModel.Id = id;
            editModel.EventId = this.GetAdById(id).Event.Id;

            this.adsRepository.Update(editModel);
            await this.adsRepository.SaveChangesAsync();

            var response = await this.adsRepository.GetByIdAsync(id);

            return Mapper.Map<AdResponseModel>(response);
        }

        public AdResponseModel GetAdById(int id)
        {
            return this.adsRepository.All().Where(e => e.Id == id).To<AdResponseModel>().FirstOrDefault();
        }

        public IEnumerable<AdResponseModel> GetAdsByType(string type)
        {
            return this.adsRepository.All().Where(a => a.Type.Type == type && a.Active == true).To<AdResponseModel>().ToList();
        }

        public bool ContainsAdsType(string type)
        {
            return this.adsTypeRepository.All().FirstOrDefault(a => a.Type == type) != null;
        }

        public IEnumerable<AdResponseModel> GetAllAds()
        {
            return this.adsRepository.All().Where(a => a.Active == true).To<AdResponseModel>().ToList();
        }

        public AdTypeResponseModel GetAdTypeById(int id)
        {
            return this.adsTypeRepository.All().Where(a => a.Id == id).To<AdTypeResponseModel>().FirstOrDefault();
        }
    }
}
