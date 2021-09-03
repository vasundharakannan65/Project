using CasaDelight.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDelight.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Dish> Dish;
        public IEnumerable<Order> Order;
    }
}
