using FSK_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface ITankRepo
    {
        public List<Tank> GetTank();

        public Tank GetTankById(string id);

        public bool AddTank(Tank tank);

        public bool UpdateTank(Tank tank);

        public bool DeleteTank(string tankId);

        public List<Tank> GetTankByFilter(string search, int elementID);

        public List<Tank> GetTankByElement(int elementID);
    }
}
