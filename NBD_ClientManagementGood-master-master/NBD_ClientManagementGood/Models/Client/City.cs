using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class City
    {
        public City()
        {
            this.Clients = new HashSet<Client>();
        }

        public int CityID { get; set; }

        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "You cannot leave the State blank.")]
        [StringLength(30, ErrorMessage = "State name cannot be more than 30 characters long.")]
        public string State { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
