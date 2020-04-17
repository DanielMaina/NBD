using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Material
    {
        public Material()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Display(Name = "Material Name")]
        [Required(ErrorMessage = "The material must have a name")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Material Desctiption")]
        [Required(ErrorMessage = "The material must have a description")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
        public string Description { get; set; }

        [Display(Name = "Material Unit")] 
        [Required(ErrorMessage = "The material must have a unit")]
        [StringLength(10, ErrorMessage = "The name cannot be longer than 10 characters")]
        public string Unit { get; set; }

        [Display(Name = "Listing Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int List { get; set; }

        [Display(Name = "OIS")]
        public int OIS { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
