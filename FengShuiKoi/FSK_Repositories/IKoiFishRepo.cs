﻿using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface IKoiFishRepo
    {
        public List<KoiFish> GetKoiFishs();
        public KoiFish GetKoiFishById(int id);

        public KoiFish GetKoiFishByElement(string element);
    }
}
