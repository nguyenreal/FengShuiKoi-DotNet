using FSK_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class KoiFishDAO
    {
        private FengShuiKoiDbContext _dbContext;
        private static KoiFishDAO _instance;

        public static KoiFishDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KoiFishDAO();
                return _instance;
            }
        }

        public KoiFishDAO()
        {
            _dbContext = new FengShuiKoiDbContext();
        }

        public List<KoiFish> GetKoiFish()
        {
            return _dbContext.KoiFishes.ToList();
        }

        public KoiFish GetKoiFishById(string id)
        {
            return _dbContext.KoiFishes.SingleOrDefault(k => k.KoiId.Equals(id));
        }

        public bool AddKoiFish(KoiFish koiFish)
        {
            bool result = false;
            KoiFish koiFish1 = GetKoiFishById(koiFish.KoiId);
            if(koiFish1 == null)
            {
                _dbContext.KoiFishes.Add(koiFish);
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            bool result = false;
            KoiFish koiFish1 = GetKoiFishById(koiFish.KoiId);
            if (koiFish1 != null)
            {
                _dbContext.KoiFishes.Attach(koiFish);
                _dbContext.Entry<KoiFish>(koiFish).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteKoiFish(string koiId)
        {
            bool result = false;
            KoiFish koiFish = GetKoiFishById(koiId);
            if(koiFish != null)
            {
                _dbContext.KoiFishes.Remove(koiFish);
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public List<KoiFish> GetKoiFishByFilter(string search, int elementID)
        {
            var query = _dbContext.KoiFishes
                .Where(a => EF.Functions.Like(a.Name, "%" + search + "%"));

            //if (elementID != -1)
            //{
            //    query = query.Where(a => a.KoiId == elementID);
            //}
            return query.ToList();
        }
    }
}
