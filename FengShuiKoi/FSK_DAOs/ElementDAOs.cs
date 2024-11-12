using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class ElementDAOs
    {
        private FengShuiKoiDbContext dbContext;
        private static ElementDAOs instance;
        
        public static ElementDAOs Instance
        {
            get
            {
                if(instance == null)
                    instance = new ElementDAOs();
                return instance;
            }
        }

        public ElementDAOs()
        {
            dbContext = new FengShuiKoiDbContext();
        }

        public List<Element> GetElements()
        {
            var listElement = new List<Element>();
            try
            {
                using var context = new FengShuiKoiDbContext();
                listElement = context.Elements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listElement;
        }

        public Element GetElement(int elementID)
        {
            return dbContext.Elements
                .SingleOrDefault(e => e.ElementId.Equals(elementID));
        }

        private int GetCanNumber(int birthYear)
        {
            int canTableNumber = birthYear % 10;
            int canNumber = 0;
            if (canTableNumber == 4 || canTableNumber == 5) canNumber = 1;
            if (canTableNumber == 6 || canTableNumber == 7) canNumber = 2;
            if (canTableNumber == 8 || canTableNumber == 9) canNumber = 3;
            if (canTableNumber == 0 || canTableNumber == 1) canNumber = 4;
            if (canTableNumber == 2 || canTableNumber == 3) canNumber = 5;
            return canNumber;
        }

        private int GetChiNumber(int birthYear)
        {
            int chiTableNumber = birthYear % 12;
            int chiNumber = 0;
            if (chiTableNumber == 4 || chiTableNumber == 5 || chiTableNumber == 10 || chiTableNumber == 11) chiNumber = 0;
            if (chiTableNumber == 0 || chiTableNumber == 1 || chiTableNumber == 6 || chiTableNumber == 7) chiNumber = 1;
            if (chiTableNumber == 2 || chiTableNumber == 3 || chiTableNumber == 8 || chiTableNumber == 9) chiNumber = 2;
            return chiNumber;
        }

        public int calculateElement(DateTime birthDate)
        {
            int birthYear = birthDate.Year;
            int canNumber = GetCanNumber(birthYear);
            int chiNumber = GetChiNumber(birthYear);
            int elementID = canNumber + chiNumber > 5 ? 
                canNumber + chiNumber : canNumber + chiNumber - 5;
            return elementID;
        }
    }
}
