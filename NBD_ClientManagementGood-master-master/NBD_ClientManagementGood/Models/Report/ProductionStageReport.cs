using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class ProductionStageReport
    {
        public int ID { get; set; }

        [Display(Name = "Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Cost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int TotalCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Mtl { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstMtl { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int LabourProdCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstLabourProdCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int DesignCost { get; set; }

        [Display(Name = "Estimated Bid Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EstDesignCost { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
