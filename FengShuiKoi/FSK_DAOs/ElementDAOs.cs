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
    }
}
