using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Labour
    {
        public int ProductionID { get; set; }

        public virtual Production Production { get; set; }

        public int LabourUnitID { get; set; }

        public virtual LabourUnit LabourUnit { get; set; }
    }
}
