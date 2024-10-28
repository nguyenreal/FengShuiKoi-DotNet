﻿using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface IAdvertisementServices
    {
        bool SaveAdvertisement(Advertisement advertisement);
        bool DeleteAdvertisement(Advertisement advertisement);
        bool UpdateAdvertisement(Advertisement advertisement);
        List<Advertisement> GetAdvertisements();
        Advertisement GetAdvertisement(String id);
    }
}
