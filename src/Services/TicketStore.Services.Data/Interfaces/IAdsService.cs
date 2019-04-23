﻿namespace TicketStore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicketStore.Web.Shared.Ads;

    public interface IAdsService
    {
        IEnumerable<AdResponseModel> GetAllAds();

        bool ContainsAdsType(string type);

        IEnumerable<AdResponseModel> GetAdsByType(string type);
        Task<AdResponseModel> AddAd(CreateAdRequestModel model);
    }
}
