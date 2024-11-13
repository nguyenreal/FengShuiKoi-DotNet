using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface ITankRepo
    {
        List<Tank> GetTanks();
        Tank GetTankById(string tid);
        Tank GetTankByElementId(int id);
        Tank GetTankByShape(string shape);
        void AddTank(Tank tank);
        void UpdateTank(Tank tank);
    }
}
