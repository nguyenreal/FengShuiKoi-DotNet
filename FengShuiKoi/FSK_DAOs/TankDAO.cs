using FSK_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class TankDAO
    {
        private FengShuiKoiDbContext _dbContext;
        private static TankDAO _instance;

        public static TankDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TankDAO();
                return _instance;
            }
        }

        public TankDAO()
        {
            _dbContext = new FengShuiKoiDbContext();
        }

        public List<Tank> GetTank()
        {
            return _dbContext.Tanks.Include(t => t.Element).ToList();
        }

        public Tank GetTankById(string id)
        {
            return _dbContext.Tanks.SingleOrDefault(k => k.TankId.Equals(id));
        }

        public bool AddTank(Tank tank)
        {
            bool result = false;
            Tank tank1 = GetTankById(tank.TankId);
            if (tank1 == null)
            {
                _dbContext.Tanks.Add(tank);
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateTank(Tank tank)
        {
            bool result = false;
            Tank tank1 = GetTankById(tank.TankId);
            if (tank1 != null)
            {
                _dbContext.Tanks.Attach(tank);
                _dbContext.Entry<Tank>(tank).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteTank(string tankId)
        {
            bool result = false;
            Tank tank = GetTankById(tankId);
            if (tank != null)
            {
                _dbContext.Tanks.Remove(tank);
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public List<Tank> GetTankByFilter(string search, int elementID)
        {
            var query = _dbContext.Tanks
                .Where(a => EF.Functions.Like(a.Shape, "%" + search + "%"));

            if (elementID != -1)
            {
                query = query.Where(a => a.ElementId == elementID);
            }
            return query.ToList();
        }
    }
}
