using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface ITankService
    {
        public List<Tank> GetTank();

        public Tank GetTankById(string id);

        public bool AddTank(Tank tank);

        public bool UpdateTank(Tank tank);

        public bool DeleteTank(string tankId);

        public List<Tank> GetTanksByFilter(string search, int elementID);
    }
}
