using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class DesignDaily
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(1, ErrorMessage = "Last name cannot be more than 1 character.")]
        public string Stage { get; set; }

        [Display(Name = "Hours")]
        //[DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public int Hours { get; set; }

        [Display(Name = "Task Description")]
        [Required(ErrorMessage = "You cannot leave the task description blank")]
        [StringLength(250, ErrorMessage = "The description cannot be more than 250 characters long.")]
        public string Task { get; set; }

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
