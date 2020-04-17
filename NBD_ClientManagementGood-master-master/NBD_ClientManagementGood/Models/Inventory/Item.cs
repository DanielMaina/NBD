using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Item
    {
        public Item()
        {
            Products = new HashSet<Product>();
            InvBids = new HashSet<InvBid>();
            ProductionItems = new HashSet<ProductionItem>();
        }

        public int ID { get; set; }

        [Display(Name = "Item Type")]
        [StringLength(100, ErrorMessage = "The task name cannot be more than 100 characters long.")]
        public string Type { get; set; }

        [Display(Name = "Inventory Code")]
        [Required(ErrorMessage = "You must enter a Inventory Code")]
        [StringLength(256, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public string Code { get; set; }

        [Display(Name = "Inventory Size")]
        [StringLength(100, ErrorMessage = "The task name cannot be more than 100 characters long.")]
        public string Size { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "You must enter a Number")]
        [RegularExpression("^\\d{0,5}$", ErrorMessage = "5 numbers max")]
        public int Qty { get; set; }

        [Display(Name = "Per unit")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Net { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double TotalCost { get; set; }

        [Display(Name = "Estimated Delivery Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a delivery Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Estimated install Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InstallDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<InvBid> InvBids { get; set; }

        public virtual ICollection<ProductionItem> ProductionItems { get; set; }
    }
}
