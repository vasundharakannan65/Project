using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDelight.ViewModels
{
    public class CreateViewModel
    {
        public string DishName { get; set; }
        public IFormFile DishImage { get; set; }
        public string DishDesc { get; set; }
        public double DishPrice { get; set; }
        public int DishQty { get; set; }
    }
}
