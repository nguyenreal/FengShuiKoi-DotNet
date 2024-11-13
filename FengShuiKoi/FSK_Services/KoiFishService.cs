using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepo _koiFishRepo;
        public KoiFishService()
        {
            _koiFishRepo = new KoiFishRepo();
        }

        public bool AddKoiFish(KoiFish koiFish) => _koiFishRepo.AddKoiFish(koiFish);

        public bool DeleteKoiFish(string koiId) => _koiFishRepo.DeleteKoiFish(koiId);

        public List<KoiFish> GetKoiFish() => _koiFishRepo.GetKoiFish();

        public List<KoiFish> GetKoiFishByFilter(string search, int elementID) => _koiFishRepo.GetKoiFishByFilter(search, elementID);

        public KoiFish GetKoiFishById(string id) => _koiFishRepo.GetKoiFishById(id);

        public bool UpdateKoiFish(KoiFish koiFish) => _koiFishRepo.UpdateKoiFish(koiFish);
    }
}
