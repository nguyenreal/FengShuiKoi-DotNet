using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface IKoiFishService
    {
        public List<KoiFish> GetKoiFish();

        public KoiFish GetKoiFishById(string id);

        public bool AddKoiFish(KoiFish koiFish);

        public bool UpdateKoiFish(KoiFish koiFish);

        public bool DeleteKoiFish(string koiId);

        public List<KoiFish> GetKoiFishByFilter(string search, int elementID);
    }
}
