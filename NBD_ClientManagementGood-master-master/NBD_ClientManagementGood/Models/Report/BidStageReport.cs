using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class BidStageReport
    {
        public int ID { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstBID { get; set; }

        [Display(Name = "Estimated Hours")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Hours { get; set; }

        [Display(Name = "Current Hours")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstHours { get; set;}

        [Display(Name = "CurrentCost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Costs { get; set; }

        [Display(Name = "Total Estimated Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstCost { get; set; }

        [Display(Name = "Hours Remaining")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int HoursRemaining { get; set; }

        [Display(Name = "Costs Remaining")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int CostsRemaining { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
