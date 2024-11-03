using FSK_BusinessObjects;
using Microsoft.EntityFrameworkCore;

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
            if (advertisement != null)
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

        public List<Advertisement> GetAdvertisementsByFilter(string category, string userID, string element)
        {
            using (var context = new FengShuiKoiDbContext())
            {
                var query = context.Advertisements
                    .Include(ad => ad.Category)
                    .Include(ad => ad.User)
                    .Include(ad => ad.Element)
                    .Where(ad => ad.Status == "Active");

                // filter by category
                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(ad => ad.Category.CategoryId == category);
                }

                // filter by userID
                if (!string.IsNullOrEmpty(userID))
                {
                    query = query.Where(ad => ad.User.UserId == userID);
                }

                // filter by element
                if (!string.IsNullOrEmpty(element))
                {
                    query = query.Where(ad => ad.Element.ElementName == element);
                }
                return query.ToList();
            }
        }
    }
}
