using FSK_BusinessObjects;
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
        public bool DeleteAdvertisement(Advertisement advertisement) => AdvertisementDAOs.Instance.DeleteAd(advertisement);

        public Advertisement GetAdvertisement(String id) => AdvertisementDAOs.Instance.GetAdvertisementByID(id);

        public List<Advertisement> GetAdvertisements() => AdvertisementDAOs.Instance.GetAdvertisements();

        public bool SaveAdvertisement(Advertisement advertisement) => AdvertisementDAOs.Instance.SaveAd(advertisement);

        public bool UpdateAdvertisement(Advertisement advertisement) => AdvertisementDAOs.Instance.UpdateAd(advertisement);
    }
}
