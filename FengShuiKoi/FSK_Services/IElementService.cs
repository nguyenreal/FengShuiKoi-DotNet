using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface IElementService
    {
        Element GetElement(int elementID);
        List<Element> GetElements();

        Element GetElement(DateTime birthDate);
    }
}
