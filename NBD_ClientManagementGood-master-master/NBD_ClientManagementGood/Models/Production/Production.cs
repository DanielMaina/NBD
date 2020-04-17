using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Production
    {
        public Production()
        {
            Labour = new HashSet<Labour>();
            ProductionItems = new HashSet<ProductionItem>();
            LabourDepartments = new HashSet<LabourDepartment>();
        }

        public int ID { get; set; }

        [Display(Name = "Total hourly rate")]
        //[DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public double ProEstHourly { get; set; }

        [Display(Name = "Total Material Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]       
        public double ProEstMaterialCost { get; set; }

        //[Display(Name = "Total Cost")]
        //[DataType(DataType.Currency)]
        //[Required(ErrorMessage = "You must enter a Amount")]
        //[RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        //public double ProEstTotalHours { get; set; }       

        [Display(Name = "Percent")]
        [Range(1, 100)]
        public double ProBidPercent { get; set; }

        public double TotalCost
        {
            get
            {
                return ProEstHourly + ProEstMaterialCost;
            }
        }

        //public string meme
        //{
        //    get
        //    {
        //        double percent = Math.Round(TotalCost / Bid.Amount, 2) * 100;
        //        return Convert.ToString(percent) + "%";
        //    }
        //}

        public int BidID { get; set; }

        public virtual Bid Bid { get; set; }

        public  ICollection<LabourDepartment> LabourDepartments { get; set; }

        public  ICollection<Labour> Labour { get; set; }

        public  ICollection<ProductionItem> ProductionItems { get; set; }
       
    }
}
