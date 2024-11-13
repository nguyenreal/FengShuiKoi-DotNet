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
        private readonly IKoiFishRepo ikoifishRepo;
        public KoiFishService()
        {
            ikoifishRepo = new KoiFishRepo();
        }
        public KoiFish GetKoiFishByElement(string element) => ikoifishRepo.GetKoiFishByElement(element);
        

        public KoiFish GetKoiFishById(int id) => ikoifishRepo.GetKoiFishById(id);
        

        public List<KoiFish> GetKoiFishs() => ikoifishRepo.GetKoiFishs();
        
    }
}
