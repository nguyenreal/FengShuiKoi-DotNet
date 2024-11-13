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
        public List<KoiFish> GetKoiFishs();

        public KoiFish GetKoiFishByElement(string element);

        public KoiFish GetKoiFishById(int id);
    }
}
