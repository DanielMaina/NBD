using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class LabourUnit
    {
        public LabourUnit()
        {
            Labours = new HashSet<Labour>();  
        }

        public int ID { get; set; }

        [Display(Name = "Unit Description")]
        [Required(ErrorMessage = "You cannot leave the unit description blank")]
        [StringLength(250, ErrorMessage = "The description cannot be more than 250 characters long.")]
        public string Description { get; set; }

        [Display(Name = "Price per hour")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Price { get; set; }

        [Display(Name = "Cost per hour")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Cost { get; set; }

        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "You cannot leave the task name blank")]
        [StringLength(100, ErrorMessage = "The task name cannot be more than 100 characters long.")]
        public string TaskName { get; set; }

        [Display(Name = "Task Description")]
        [Required(ErrorMessage = "You cannot leave the task description blank")]
        [StringLength(1000, ErrorMessage = "The description cannot be more than 1000 characters long.")]
        public string TaskDescription { get; set; }

        public virtual ICollection<Labour> Labours { get; set; }

        //public int BidID { get; set; }

        //public virtual Bid Bid { get; set; }
    }
}
