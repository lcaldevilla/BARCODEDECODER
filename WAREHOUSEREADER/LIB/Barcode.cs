using System;
using System.Collections.Generic;
using System.Text;

namespace WAREHOUSEREADER.LIB
{
    class Barcode
    {
        public string GTIN { get; set; }
        public string Serial { get; set; }
        public string Batch { get; set; }
        public string Expire { get; set; }
    }
}
