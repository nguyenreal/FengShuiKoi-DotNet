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
        public List<Element> GetElements() => ElementDAOs.Instance.GetElements();
    }
}
