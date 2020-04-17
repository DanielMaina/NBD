using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Client
    {
        public int ClientID { get; set; }

        public Client()
        {
            Projects = new HashSet<Project>();
        }

        [Display(Name = "Formal Name")]
        public string FormalName
        {
            get
            {
                return FirstName
                   + (string.IsNullOrEmpty(MiddleName) ? " " :
                       (" " + (char?)MiddleName[0] + ". ").ToUpper())
                   + LastName;
            }
            set { }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255)]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(255)]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        //[Required(ErrorMessage = "Position is required.")]
        //[StringLength(255)]s
        //public string Position { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public int CityID { get; set; }

        public virtual City City { get; set; }
    }
}
