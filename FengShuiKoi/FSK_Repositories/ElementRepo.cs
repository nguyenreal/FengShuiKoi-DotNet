using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class ElementRepo : IElementRepo
    {
        public Element ConsultingElement(DateTime birthDate) =>
            ElementDAOs.Instance.GetElement(ElementDAOs.Instance.calculateElement(birthDate));

        public List<Element> GetElements() => ElementDAOs.Instance.GetElements();
    }
}
