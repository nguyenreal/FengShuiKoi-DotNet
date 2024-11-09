using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface IAdvertisementServices
    {
        bool AddAdvertisement(Advertisement advertisement);
        bool DeleteAdvertisement(string adID);
        bool UpdateAdvertisement(Advertisement advertisement);
        List<Advertisement> GetAdvertisements();
        Advertisement GetAdvertisement(String id);
        List<Advertisement> GetAdvertisementsByFilter(string element, string userID, string category, string search);
    }
}
