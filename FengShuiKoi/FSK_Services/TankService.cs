using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class TankService : ITankService
    {
        private readonly ITankRepo itankrepo;
        public TankService()
        {
            itankrepo = new TankRepo();
        }

        public void AddTank(Tank tank) => itankrepo.AddTank(tank);
        

        public Tank GetTankByElement(int id) => itankrepo.GetTankByElementId(id);
        

        public Tank GetTankById(string tid) => itankrepo.GetTankById(tid);


        public Tank GetTankByShape(string shape) => itankrepo.GetTankByShape(shape);
        

        public List<Tank> GetTanks() => itankrepo.GetTanks();   
        

        public void UpdateTank(Tank tank) => itankrepo.UpdateTank(tank);
        
    }
}
