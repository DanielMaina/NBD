using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Tool
    {
        public Tool()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Display(Name = "Tool Name")]
        [Required(ErrorMessage = "The tool must have a name")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Tool Desctiption")]
        [Required(ErrorMessage = "The tool must have a description")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
