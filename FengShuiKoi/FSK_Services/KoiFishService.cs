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

        public List<KoiFishViewModel> GetKoiFishByFilter(string search)
        {
            var koiFishes = _koiFishRepo.GetKoiFishByFilter(search);
            return koiFishes.Select(koi => new KoiFishViewModel
            {
                KoiId = koi.KoiId,
                Name = koi.Name,
                Color = koi.Color,
                Description = koi.Description,
                Size = koi.Size,
                Weight = koi.Weight,
                ElementsString = string.Join(", ", koi.Elements.Select(e => e.ElementName))
            }).ToList();
        }

        public KoiFish GetKoiFishById(string id) => _koiFishRepo.GetKoiFishById(id);

        public List<KoiFishViewModel> GetKoiFishElementView()
        {
            var koiFishes = _koiFishRepo.GetKoiFish();
            return koiFishes.Select(koi => new KoiFishViewModel
            {
                KoiId = koi.KoiId,
                Name = koi.Name,
                Color = koi.Color,
                Description = koi.Description,
                Size = koi.Size,
                Weight = koi.Weight,
                ElementsString = string.Join(", ", koi.Elements.Select(e => e.ElementName))
            }).ToList();
        }

        public bool UpdateKoiFish(KoiFish koiFish) => _koiFishRepo.UpdateKoiFish(koiFish);
    }
}
