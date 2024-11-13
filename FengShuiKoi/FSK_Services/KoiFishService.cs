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

        public List<KoiFish> GetKoiFish() => _koiFishRepo.GetKoiFish();

        public KoiFish GetKoiFishById(string id) => _koiFishRepo.GetKoiFishById(id);

        public List<KoiFish> GetKoiFishByFilter(string search) => _koiFishRepo.GetKoiFishByFilter(search);

        public bool AddKoiFish(KoiFish koiFish, List<int> elementIds) => _koiFishRepo.AddKoiFish(koiFish, elementIds);

        public bool UpdateKoiFish(KoiFish koiFish, List<int> elementIds) => _koiFishRepo.UpdateKoiFish(koiFish, elementIds);

        public bool DeleteKoiFish(string koiId) => _koiFishRepo.DeleteKoiFish(koiId);

    }
}
