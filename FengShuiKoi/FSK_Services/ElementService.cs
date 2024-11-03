using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class ElementService : IElementService
    {
        private readonly IElementRepo iElementRepo;
        public ElementService()
        {
            iElementRepo = new ElementRepo();
        }
        public List<Element> GetElements()
        {
            return iElementRepo.GetElements();
        }
    }
}
