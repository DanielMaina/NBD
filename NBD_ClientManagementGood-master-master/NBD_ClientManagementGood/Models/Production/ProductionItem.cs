using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class ProductionItem
    {
        public int ProductionID { get; set; }

        public virtual Production Production { get; set; }

        public int ItemID { get; set; }

        public virtual Item Item { get; set; }
    }
}
