﻿using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        private readonly IAdvertisementRepo iAdvertisementRepo;
        public AdvertisementServices()
        {
            iAdvertisementRepo = new AdvertisementRepo();
        }
        public bool DeleteAdvertisement(string adID)
        {
            return iAdvertisementRepo.DeleteAdvertisement(adID);
        }

        public Advertisement GetAdvertisement(string id)
        {
            return iAdvertisementRepo.GetAdvertisement(id);
        }

        public List<Advertisement> GetAdvertisements()
        {
            return iAdvertisementRepo.GetAdvertisements();
        }

        public bool AddAdvertisement(Advertisement advertisement)
        {
            return iAdvertisementRepo.AddAdvertisement(advertisement);
        }

        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            return iAdvertisementRepo.UpdateAdvertisement(advertisement);
        }

        public List<Advertisement> GetAdvertisementsByFilter(string search, int elementID)
        {
            return iAdvertisementRepo.GetAdvertisementsByFilter(search, elementID);
        }

        public List<Advertisement> GetAdvertisementsByElement(int elementID)
        {
            return iAdvertisementRepo.GetAdvertisementsByElement(elementID);
        }

        public List<Advertisement> GetVerifiedAdvertisements()
        {
            return iAdvertisementRepo.GetVerifiedAdvertisements();
        }
    }
}
