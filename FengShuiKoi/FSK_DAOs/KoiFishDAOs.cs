using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class KoiFishDAOs
    {
        private FengShuiKoiDbContext dbcontext;
        private static KoiFishDAOs instance;

        public static KoiFishDAOs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiFishDAOs();
                }
                return instance;
            }
        }

        public KoiFishDAOs()
        {
            dbcontext = new FengShuiKoiDbContext();
        }

        public List<KoiFish> GetKoiFishs()
        {
            var listElement = new List<KoiFish>();
            try
            {
                using var context = new FengShuiKoiDbContext();
                listElement = context.KoiFishes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listElement;
        }

        public KoiFish GetKoiFishByElement(string element)
        {
            return dbcontext.KoiFishes.SingleOrDefault(k => k.Elements.Equals(element));
        }

        public KoiFish GetKoiFishById(int id)
        {
            return dbcontext.KoiFishes.SingleOrDefault(m => m.KoiId.Equals(id));
        }
    }
}
