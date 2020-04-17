using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Plant
    {
        public Plant()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Display(Name = "Plant Name")]
        [Required(ErrorMessage = "The Plant must have a name")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Plant Desctiption")]
        [Required(ErrorMessage = "The Plant must have a description")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
        public string Description { get; set; }

        [Display(Name = "Last Ordered")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastOrdered { get; set; }

        [Display(Name = "Listing Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int AvgNet { get; set; }

        [Display(Name = "Listing Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int List { get; set; }

        [Display(Name = "OIS")]
        public int OIS { get; set; }

        [Display(Name = "IS/OB")]
        public int IS_OB { get; set; }

        [Display(Name = "OOO")]
        public int OOO { get; set; }

        [Display(Name = "OO/OB")]
        public int OO_OB { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
