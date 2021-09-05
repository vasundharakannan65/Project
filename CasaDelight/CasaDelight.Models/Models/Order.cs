using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDelight.Models.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Phone]
        public int PhoneNumber { get; set; }

        //public double TotalCost { get; set; }
        public ICollection<Dish> CartList { get; set; }
    }
}
