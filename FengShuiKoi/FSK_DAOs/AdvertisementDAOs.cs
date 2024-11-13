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
            dbContext = new FengShuiKoiDbContext();
            return dbContext.Advertisements
                .Include(c => c.Category)
                .Include(c => c.Element)
                .ToList();
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

        public List<Advertisement> GetAdvertisementsByFilter(string search, int elementID)
        {
            try
            {
                using var context = new FengShuiKoiDbContext();
                var query = context.Advertisements
                    .Where(a => EF.Functions.Like(a.Title, "%" + search + "%"));

                if (elementID != -1)
                {
                    query = query.Where(a => a.ElementId == elementID);
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Advertisement>();
            }
        }
    }
}
