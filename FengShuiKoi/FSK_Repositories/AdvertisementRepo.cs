﻿using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class AdvertisementRepo : IAdvertisementRepo
    {

        public bool DeleteAdvertisement(string adID) => AdvertisementDAOs.Instance.DeleteAd(adID);

        public Advertisement GetAdvertisement(String id) => AdvertisementDAOs.Instance.GetAdvertisementByID(id);

        public List<Advertisement> GetAdvertisements() => AdvertisementDAOs.Instance.GetAdvertisements();

        public List<Advertisement> GetAdvertisementsByFilter(string element, string userID, string category, string search) 
            => AdvertisementDAOs.Instance.GetAdvertisementsByFilter(element, userID, category, search);
  
        public bool AddAdvertisement(Advertisement advertisement) => AdvertisementDAOs.Instance.AddAd(advertisement);

        public bool UpdateAdvertisement(Advertisement advertisement) => AdvertisementDAOs.Instance.UpdateAd(advertisement);

    }
}