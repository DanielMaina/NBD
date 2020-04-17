using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class ProDMaterial
    {
        public int ID { get; set; }

        [Display(Name = "Inventory Code")]
        [Required(ErrorMessage = "You must enter a Inventory Code")]
        [StringLength(256, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public string Code { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "You must enter a Number")]
        [RegularExpression("^\\d{0,5}$", ErrorMessage = "5 numbers max")]
        public int Qty { get; set; }

        [Display(Name = "Per unit")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Net { get; set; }

        [Display(Name = "Toal Cost")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double TotalCost
        {
            get
            {
                return Qty * Net;
            }
        }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string Submitter { get; set; }

        [Display(Name = "SubmissionDate")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a submission date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
