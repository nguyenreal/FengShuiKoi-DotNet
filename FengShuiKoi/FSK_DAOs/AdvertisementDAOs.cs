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
            return dbContext.Advertisements.Include(c => c.Category).ToList();
        }

        public bool AddAd(Advertisement advertisement)
        {
            bool isSuccess = false;
            if(GetAdvertisementByID(advertisement.AdId) == null )
            {
                dbContext.Advertisements.Add(advertisement);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool UpdateAd(Advertisement advertisement)
        {
            bool isSuccess = false;
            using var context = new FengShuiKoiDbContext();
            Advertisement advertisement1 = GetAdvertisementByID(advertisement.AdId);
            if(advertisement1 != null )
            {
                context.Advertisements.Attach(advertisement);
                context.Entry<Advertisement>(advertisement).State 
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                isSuccess = true;
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
            return isSuccess;
        }

        public Advertisement GetAdvertisementByID(string adID)
        {
            return dbContext.Advertisements.SingleOrDefault(a => a.AdId.Equals(adID));
        }

        public List<Advertisement> GetAdvertisementsByFilter(string category, string userID, string element, string search)
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
                    query = query.Where(ad => ad.Category.CategoryId == category 
                    && ad.Category.CategoryName.Contains(search));
                }

                // filter by userID
                if (!string.IsNullOrEmpty(userID))
                {
                    query = query.Where(ad => ad.User.UserId == userID 
                    && ad.UserId.Contains(search));
                }

                // filter by element
                if (!string.IsNullOrEmpty(element))
                {
                    query = query.Where(ad => ad.Element.ElementName == element 
                    && ad.Element.ElementName.Contains(search));
                }
                return query.ToList();
            }
        }
    }
}
