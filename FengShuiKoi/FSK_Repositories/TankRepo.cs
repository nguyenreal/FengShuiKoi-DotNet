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
        public void AddTank(Tank tank) => TankDAO.Instance.AddTank(tank);


        public Tank GetTankByElementId(int id) => TankDAO.Instance.GetTankByElementId(id);


        public Tank GetTankById(string tid) => TankDAO.Instance.GetTankById(tid);


        public Tank GetTankByShape(string shape) => TankDAO.Instance.GetTankByShape(shape);
        

        public List<Tank> GetTanks() => TankDAO.Instance.GetTanks();
        

        public void UpdateTank(Tank tank) => TankDAO.Instance.UpdateTank(tank);
        
    }
}
