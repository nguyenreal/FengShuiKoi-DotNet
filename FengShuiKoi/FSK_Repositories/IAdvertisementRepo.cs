using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface IAdvertisementRepo
    {
        bool AddAdvertisement(Advertisement advertisement);
        bool DeleteAdvertisement(string adID);
        bool UpdateAdvertisement(Advertisement advertisement);
        List<Advertisement> GetAdvertisements();
        Advertisement GetAdvertisement(String id);
        List<Advertisement> GetAdvertisementsByFilter(string search, int elementID);
        List<Advertisement> GetAdvertisementsByElement(int elementID);
        List<Advertisement> GetVerifiedAdvertisements();
    }
}
