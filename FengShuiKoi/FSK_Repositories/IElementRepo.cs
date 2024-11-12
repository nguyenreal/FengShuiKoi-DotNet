using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface IElementRepo
    {
        public List<Element> GetElements();

        public Element ConsultingElement(DateTime birthDate);
    }
}
