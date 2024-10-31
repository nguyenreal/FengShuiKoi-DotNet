using FSK_BusinessObjects;

namespace FSK_DAOs
{
    public class AdvertisementDAOs
    {
        private FengShuiKoiDbContext dbContext;
        private static AdvertisementDAOs instance;

        public static AdvertisementDAOs Instance
        {
            get
            {
                if (instance == null)
                    instance = new AdvertisementDAOs();
                return instance;
            }
        }

        public AdvertisementDAOs()
        {
            dbContext = new FengShuiKoiDbContext();
        }

        public List<Advertisement> GetAdvertisements()
        {
            var listAds = new List<Advertisement>();
            try
            {
                using var context = new FengShuiKoiDbContext();
                listAds = context.Advertisements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAds;
        }

        public bool AddAd(Advertisement advertisement)
        {
            bool isSuccess = false;
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Advertisements.Add(advertisement);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool UpdateAd(Advertisement advertisement)
        {
            bool isSuccess = false;
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Entry<Advertisement>(advertisement).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool DeleteAd(string adID)
        {
            bool isSuccess = false;
            using var context = new FengShuiKoiDbContext();
            Advertisement advertisement = GetAdvertisementByID(adID);
            if(advertisement != null)
            {
                context.Advertisements.Remove(advertisement);
                context.SaveChanges();
                isSuccess = true;
            }
            else
            {
                throw new Exception("Advertisement not exist!");
            }
            return isSuccess;
        }

        public Advertisement GetAdvertisementByID(string adID)
        {
                using var db = new FengShuiKoiDbContext();
                return db.Advertisements
                .FirstOrDefault(c => c.AdId.Equals(adID));
        }

        public List<Advertisement> GetAdvertisementByFilter(string element, string userID, string category)
        {
            List<Advertisement> advertisements = GetAdvertisements();
            List<Advertisement> listAds = new List<Advertisement>();
            foreach(Advertisement ad in advertisements)
            {
                if(ad.UserId.Equals(userID)
                    && ad.Category.Equals(category) 
                    && ad.Element.Equals(element))
                {
                    listAds.Add(ad);
                }
            }
            return listAds;
        }
    }
}
