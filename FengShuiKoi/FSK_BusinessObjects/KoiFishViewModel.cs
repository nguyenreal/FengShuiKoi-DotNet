using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_BusinessObjects
{
    public class KoiFishViewModel
    {
        public string KoiId { get; set; } = null!;

        public string? Name { get; set; }

        public string? Size { get; set; }

        public string? Weight { get; set; }

        public string? Color { get; set; }

        public string? Description { get; set; }

        public string ElementsString { get; set; } = null!;
    }
}
