using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public int CountryID { get; set; }

        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
