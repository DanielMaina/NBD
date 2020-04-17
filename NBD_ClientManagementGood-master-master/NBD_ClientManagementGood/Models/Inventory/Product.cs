using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Product
    {

        public int MaterialID { get; set; }

        public virtual Material Material { get; set; }

        public int PlantID { get; set; }

        public virtual Plant Plant { get; set; }

        public int PotteryID { get; set; }

        public virtual Pottery Pottery { get; set; }

        public int ToolID { get; set; }

        public virtual Tool Tool { get; set; }

        public int ItemID { get; set; }

        public virtual Item Item { get; set; }
    }
}
