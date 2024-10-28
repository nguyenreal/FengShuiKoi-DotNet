using FSK_BusinessObjects;
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
        public bool DeleteAdvertisement(Advertisement advertisement)
        {
            return iAdvertisementRepo.DeleteAdvertisement(advertisement);
        }

        public Advertisement GetAdvertisement(string id)
        {
            return iAdvertisementRepo.GetAdvertisement(id);
        }

        public List<Advertisement> GetAdvertisements()
        {
            return iAdvertisementRepo.GetAdvertisements();
        }

        public bool SaveAdvertisement(Advertisement advertisement)
        {
            return iAdvertisementRepo.SaveAdvertisement(advertisement);
        }

        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            return iAdvertisementRepo.UpdateAdvertisement(advertisement);
        }
    }
}
