using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class KoiFishRepo : IKoiFishRepo
    {
        public KoiFish GetKoiFishByElement(string element) => KoiFishDAOs.Instance.GetKoiFishByElement(element);


        public KoiFish GetKoiFishById(int id) => KoiFishDAOs.Instance.GetKoiFishById(id);
        

        public List<KoiFish> GetKoiFishs() => KoiFishDAOs.Instance.GetKoiFishs();
        
    }
}
