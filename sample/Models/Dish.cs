using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [Display(Name ="Image")]
        public string DishImage { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string DishName { get; set; }

        [Required]
        [Display(Name ="Description")]
        [StringLength(250)]
        public string DishDesc { get; set; }

        [Required]
        [Display(Name ="Price")]
        public double DishPrice { get; set; }

        public int DishQty { get; set; }
    }
}
