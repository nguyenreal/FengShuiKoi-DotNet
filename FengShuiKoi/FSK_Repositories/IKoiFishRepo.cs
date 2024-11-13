using FSK_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface IKoiFishRepo
    {
        List<KoiFish> GetKoiFish();
        KoiFish GetKoiFishById(string id);
        List<KoiFish> GetKoiFishByFilter(string search);
        bool AddKoiFish(KoiFish koiFish, List<int> elementIds);
        bool UpdateKoiFish(KoiFish koiFish, List<int> elementIds);
        bool DeleteKoiFish(string koiId);
    }
}
