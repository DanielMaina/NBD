using NBD_ClientManagementGood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Project
    {
        public Project()
        {
            Bids = new HashSet<Bid>();
        }

        public int ID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "You can not leave this project name field blank")]
        [StringLength(100, ErrorMessage = "Project name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Intial Start")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a Completion Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a Completion Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<DesignBudget> DesignBudgets { get; set; }
        public virtual ICollection<DesignDaily> DesignDailies { get; set; }
        public virtual ICollection<LabourReport> LabourReports { get; set; }
        public virtual ICollection<ProDLabour> ProDLabours { get; set; }
        public virtual ICollection<ProDMaterial> ProDMaterials { get; set; }
        public virtual ICollection<BidStageReport> BidStageReports { get; set; }
        public virtual ICollection<ProductionStageReport> ProductionStageReports { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

    }
}
