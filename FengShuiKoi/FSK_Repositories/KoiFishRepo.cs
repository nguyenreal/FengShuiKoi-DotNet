﻿using FSK_BusinessObjects;
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
        public bool AddKoiFish(KoiFish koiFish) => KoiFishDAO.Instance.AddKoiFish(koiFish);

        public bool DeleteKoiFish(string koiId) => KoiFishDAO.Instance.DeleteKoiFish(koiId);

        public List<KoiFish> GetKoiFish() => KoiFishDAO.Instance.GetKoiFish();

        public List<KoiFish> GetKoiFishByFilter(string search, int elementID) => KoiFishDAO.Instance.GetKoiFishByFilter(search, elementID);

        public KoiFish GetKoiFishById(string id) => KoiFishDAO.Instance.GetKoiFishById(id);

        public bool UpdateKoiFish(KoiFish koiFish) => KoiFishDAO.Instance.UpdateKoiFish(koiFish);
    }
}