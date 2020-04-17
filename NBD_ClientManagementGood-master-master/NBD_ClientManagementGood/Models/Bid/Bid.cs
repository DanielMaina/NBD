using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Bid
    {
        public Bid()
        {
            //BidLBs = new HashSet<BidLB>();
            InvBids = new HashSet<InvBid>();
            //LabourUnits = new HashSet<LabourUnit>();
        }

        public int ID { get; set; }

        [Display(Name = "Blueprint Code")]
        [Required(ErrorMessage = "You must enter a blueprint Code")]
        [RegularExpression("^[A-Z\\d]{12}$", ErrorMessage = "Please enter all Capital letters.")]
        [StringLength(12, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public string BlueprintCode { get; set; }

        [Display(Name = "Estimated Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstStart { get; set; }

        [Display(Name = "Estimated End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a end Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstEnd { get; set; }

        [Display(Name = "Total Estimated Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Amount { get; set; }

        [Display(Name = "Location")]
        //[Required(ErrorMessage = "You must enter a location")]
        [RegularExpression("^[A-Za-z\\s\\d]+$", ErrorMessage = "Please enter valid amount.")]
        public string Location { get; set; }

        public ICollection<InvBid> InvBids { get; set; }

        //public virtual ICollection<BidLB>  BidLBs { get; set; }

        //public virtual ICollection<LabourUnit> LabourUnits { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
