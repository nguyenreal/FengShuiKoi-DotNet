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
        private readonly ITankRepo _tankRepo;
        public TankService()
        {
            _tankRepo = new TankRepo();
        }

        public bool AddTank(Tank tank) => _tankRepo.AddTank(tank);

        public bool DeleteTank(string tankId) => _tankRepo.DeleteTank(tankId);

        public List<Tank> GetTank() => _tankRepo.GetTank();

        public List<Tank> GetTanksByFilter(string search, int elementID) => _tankRepo.GetTankByFilter(search, elementID);

        public Tank GetTankById(string id) => _tankRepo.GetTankById(id);

        public bool UpdateTank(Tank tank) => _tankRepo.UpdateTank(tank);
    }
}
