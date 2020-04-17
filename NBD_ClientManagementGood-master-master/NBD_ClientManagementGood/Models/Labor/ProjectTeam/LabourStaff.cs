using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class LabourStaff
    {
        public int StaffID { get; set; }

        public  Staff Staff { get; set; }

        public int LabourDeparmentID { get; set; }

        public  LabourDepartment LabourDepartment { get; set; }
    }
}
