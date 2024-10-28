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

        public bool SaveAd(Advertisement advertisement)
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

        public bool DeleteAd(Advertisement advertisement)
        {
            bool isSuccess = false;
            try
            {
                using var context = new FengShuiKoiDbContext();
                var a1 = context.Advertisements.SingleOrDefault(c => c.AdId == advertisement.AdId);
                if(a1 == null)
                {
                    throw new Exception("Advertisement not exist!");
                }
                context.Advertisements.Remove(a1);
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public Advertisement GetAdvertisementByID(String adID)
        {
                using var db = new FengShuiKoiDbContext();
                return db.Advertisements.FirstOrDefault(c => c.AdId.Equals(adID));
        }
    }
}
