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
        public bool AddKoiFish(KoiFish koiFish, List<int> elementIds) => KoiFishDAO.Instance.AddKoiFish(koiFish, elementIds);

        public bool DeleteKoiFish(string koiId) => KoiFishDAO.Instance.DeleteKoiFish(koiId);

        public List<KoiFish> GetKoiFish() => KoiFishDAO.Instance.GetKoiFish();

        public List<KoiFish> GetKoiFishByElement(int elementId) => KoiFishDAO.Instance.GetKoiFishByElement(elementId);

        public List<KoiFish> GetKoiFishByFilter(string search) => KoiFishDAO.Instance.GetKoiFishByFilter(search);

        public KoiFish GetKoiFishById(string id) => KoiFishDAO.Instance.GetKoiFishById(id);

        public bool UpdateKoiFish(KoiFish koiFish, List<int> elementIds) => KoiFishDAO.Instance.UpdateKoiFish(koiFish,elementIds);
    }
}
