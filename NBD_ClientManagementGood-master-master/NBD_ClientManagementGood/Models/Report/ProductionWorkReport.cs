using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class ProductionWorkReport
    {
        public ProductionWorkReport()
        {
            Items = new HashSet<Item>();
            LabourUnits = new HashSet<LabourUnit>();
        }

        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string Submitter { get; set; }

        [Display(Name = "SubmissionDate")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a submission date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<LabourUnit> LabourUnits { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
