using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class TankRepo : ITankRepo
    {
        public bool AddTank(Tank tank) => TankDAO.Instance.AddTank(tank);

        public bool DeleteTank(string tankId) => TankDAO.Instance.DeleteTank(tankId);

        public List<Tank> GetTank() => TankDAO.Instance.GetTank();

        public List<Tank> GetTankByElement(int elementID) => TankDAO.Instance.GetTanksByElement(elementID);

        public List<Tank> GetTankByFilter(string search, int elementID) => TankDAO.Instance.GetTankByFilter(search, elementID);

        public Tank GetTankById(string id) => TankDAO.Instance.GetTankById(id);

        public bool UpdateTank(Tank tank) => TankDAO.Instance.UpdateTank(tank);
    }
}
