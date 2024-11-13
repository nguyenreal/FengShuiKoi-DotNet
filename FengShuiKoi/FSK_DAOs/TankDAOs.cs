using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class TankDAO
    {
        private FengShuiKoiDbContext dbcontext;
        private static TankDAO instance;

        public static TankDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TankDAO();
                }
                return instance;
            }
        }

        public TankDAO()
        {
            dbcontext = new FengShuiKoiDbContext();
        }

        public List<Tank> GetTanks()
        {
            var listElement = new List<Tank>();
            try
            {
                using var context = new FengShuiKoiDbContext();
                listElement = context.Tanks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listElement;
        }

        public Tank GetTankById(string tid)
        {
            return dbcontext.Tanks.SingleOrDefault(m => m.TankId.Equals(tid));
        }

        public Tank GetTankByElementId(int id)
        {
            return dbcontext.Tanks.SingleOrDefault(n => n.ElementId.Equals(id));
        }

        public Tank GetTankByShape(string shape)
        {
            return dbcontext.Tanks.SingleOrDefault(s => s.Shape.Equals(shape));
        }

        public void AddTank(Tank tank)
        {
            bool isSuccess = false;
            Tank fishtank = GetTankById(tank.TankId);
            if (fishtank == null)
            {
                dbcontext.Tanks.Add(tank);
                dbcontext.SaveChanges();
                isSuccess = true;
            }
        }

        public bool UpdateTank(Tank updatetank)
        {
            var existingTank = GetTankById(updatetank.TankId);
            if (existingTank != null)
            {
                existingTank.TankId = updatetank.TankId;
                existingTank.ElementId = updatetank.ElementId;
                existingTank.Shape = updatetank.Shape;
                existingTank.ImageUrl = updatetank.ImageUrl;
                return true;
            }
            return false;
        }
    }
}
